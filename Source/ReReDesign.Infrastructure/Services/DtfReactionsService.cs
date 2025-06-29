namespace VelikiyPrikalel.ReReDesign.Infrastructure.Services;

/// <inheritdoc />
public class DtfReactionsService(IDtfLoginService loginService) : IDtfReactionsService
{
    /// <inheritdoc />
    public async Task<GetReactionsResponseApplication> GetCommentReactions(string commentId, CancellationToken cancellation)
    {
        HttpClient httpClient = new();
        string accessToken = await GetAccessToken(cancellation);

        httpClient.DefaultRequestHeaders.Add("Jwtauthorization",
            "Bearer " + accessToken);

        string url = $"https://api.dtf.ru/v2.5/comment/{commentId}/reactions?type=undefined&page=0&limit=1000";

        HttpResponseMessage response = await httpClient.GetAsync(url, cancellation);
        response.EnsureSuccessStatusCode();

        string responseContent = await response.Content.ReadAsStringAsync(cancellation);
        JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        GetReactionsResponseApplication result = JsonSerializer.Deserialize<GetReactionsResponseApplication>(responseContent, jsonOptions)!;
        return result;
    }

    /// <inheritdoc />
    public async Task<GetReactionsResponseApplication> GetPostReactions(string postId, CancellationToken cancellation)
    {
        HttpClient httpClient = new();
        string accessToken = await GetAccessToken(cancellation);

        httpClient.DefaultRequestHeaders.Add("Jwtauthorization",
            "Bearer " + accessToken);

        string url = $"https://api.dtf.ru/v2.5/content/{postId}/reactions?type=undefined&page=0&limit=1000";

        HttpResponseMessage response = await httpClient.GetAsync(url, cancellation);
        response.EnsureSuccessStatusCode();

        string responseContent = await response.Content.ReadAsStringAsync(cancellation);
        JsonSerializerOptions jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        GetReactionsResponseApplication result = JsonSerializer.Deserialize<GetReactionsResponseApplication>(responseContent, jsonOptions)!;
        return result;
    }

    private async Task<string> GetAccessToken(CancellationToken cancellation)
    {
        DtfLoginResult? loginResult = await loginService.Login(cancellation);
        if (loginResult?.Data == null)
        {
            throw new Exception("Failed to authenticate for DTF API.");
        }

        string accessToken = loginResult.Data.AccessToken;
        return accessToken;
    }
}