namespace VelikiyPrikalel.ReReDesign.Web.Controllers;

/// <summary>
/// Первый контроллер.
/// </summary>
[Route("/")]
[ApiController]
public class HomeController(
    ILogger<HomeController> logger,
    IMediator mediator) : Controller
{
    /// <summary>
    /// Главная страница.
    /// </summary>
    /// <returns><see cref="string"/>.</returns>
    [HttpGet("/hello")]
    public async Task<string> Hello()
    {
        logger.LogInformation("Hello world!");
        return "hello world";
    }
}