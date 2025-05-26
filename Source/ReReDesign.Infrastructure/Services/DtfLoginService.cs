namespace VelikiyPrikalel.ReReDesign.Infrastructure.Services;

/// <inheritdoc />
public class DtfLoginService(
    ILogger<DtfLoginService> logger,
    IOptions<DtfLoginSettings> loginOptions) : IDtfLoginService
{
    const string? LoginUrl = "https://api.dtf.ru/v3.4/auth/email/login";
    private DtfLoginSettings DtfLoginSettings => loginOptions.Value;

    /// <inheritdoc />
    public async Task<DtfLoginResult> Login(CancellationToken cancellation)
    {
        HttpClient httpClient = new();

        MultipartFormDataContent formData = new("----WebKitFormBoundary8L5jnfclCLQ5y9t5");

        formData.Add(new StringContent(DtfLoginSettings.Email), "email");

        formData.Add(new StringContent(DtfLoginSettings.Password), "password");

        try
        {
            HttpResponseMessage response = await httpClient.PostAsync(LoginUrl, formData, cancellation);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync(cancellation);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<DtfLoginResult>(responseBody);
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "Can't login");
            throw;
        }
    }
}
