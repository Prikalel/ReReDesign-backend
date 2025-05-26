namespace VelikiyPrikalel.ReReDesign.Web.Middlewares;

/// <summary>
/// Middleware для отлова исключений.
/// </summary>
public class HttpErrorResponseExceptionsHandler
{
    private readonly RequestDelegate requestDelegate;

    /// <summary>
    /// .ctor.
    /// </summary>
    /// <param name="requestDelegate">Следующий обработчик запроса <see cref="RequestDelegate"/>.</param>
    public HttpErrorResponseExceptionsHandler(RequestDelegate requestDelegate) =>
        this.requestDelegate = requestDelegate;

    /// <summary>
    /// Отлавливает необработанные исключения.
    /// </summary>
    /// <param name="httpContext">Контекст http-запроса.</param>
    /// <returns><see cref="Task"/>.</returns>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await requestDelegate.Invoke(httpContext);
        }
        catch (HttpRequestException e) when (e.StatusCode != HttpStatusCode.OK)
        {
            await WriteBadRequestResponse(httpContext, e.Message);
        }
    }

    private async Task WriteBadRequestResponse(HttpContext httpContext, string message) =>
        await httpContext.Response.WriteAsJsonAsync(new HttpError(message));
}