namespace VelikiyPrikalel.ReReDesign.Infrastructure.Services;

/// <inheritdoc />
public class DtfLoginService(
    ILogger<DtfLoginService> logger,
    IOptions<DtfLoginSettings> loginOptions,
    IMemoryCache memoryCache) : IDtfLoginService
{
    private const string LoginUrl = "https://api.dtf.ru/v3.4/auth/email/login";
    private const string CacheKey = "Login";
    private DtfLoginSettings DtfLoginSettings => loginOptions.Value;
    private readonly MemoryCacheProvider provider = new(memoryCache);

    /// <inheritdoc />
    public async Task<DtfLoginResult> Login(CancellationToken cancellation)
    {
        if (provider.TryGet(CacheKey) is (true, DtfLoginResult cachedLoginResult))
        {
            logger.LogDebug("Cache hit!");
            return cachedLoginResult;
        }

        HttpClient httpClient = new();

        MultipartFormDataContent formData = new("----WebKitFormBoundary8L5jnfclCLQ5y9t5");

        formData.Add(new StringContent(DtfLoginSettings.Email), "email");

        formData.Add(new StringContent(DtfLoginSettings.Password), "password");

        try
        {
            HttpResponseMessage response = await httpClient.PostAsync(LoginUrl, formData, cancellation);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync(cancellation);
            DtfLoginResult result = Newtonsoft.Json.JsonConvert.DeserializeObject<DtfLoginResult>(responseBody);
            provider.Put(CacheKey, result, new(GetTtl(result.Data)));
            return result;
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "Can't login");
            throw;
        }
    }

    private static TimeSpan GetTtl(DtfLoginData loginData)
    {
        DateTime expirationTime = DateTimeOffset.FromUnixTimeSeconds(loginData.AccessExpTimestamp).UtcDateTime;
        DateTime now = DateTime.UtcNow;

        TimeSpan ttl = expirationTime - now;

        if (ttl < TimeSpan.Zero)
            ttl = TimeSpan.Zero;

        return ttl;
    }
}
