namespace VelikiyPrikalel.ReReDesign.Web.Controllers;

/// <summary>
/// Контроллер для проверки реакций пользователей.
/// </summary>
[Route("v1/[controller]")]
[ApiController]
public class ReactionsController(
    ILogger<ReactionsController> logger,
    IMediator mediator) : Controller
{
    /// <summary>
    /// Получить реакции на комментарий в посте <paramref name="postId"/>.
    /// </summary>
    /// <param name="postId">Идентификатор поста, комментарий которого проверяем.</param>
    /// <param name="commentId">Идентификатор комментария в посте <paramref name="postId"/>,
    /// на который хотим получить реакции.</param>
    /// <returns><see cref="GetReactionsResponseDto"/>.</returns>
    [HttpGet("/comment")]
    public async Task<GetReactionsResponseDto> GetCommentReactions(
        [FromQuery] string postId,
        [FromQuery] string commentId)
    {
        logger.LogInformation("Reaction requested!");
        return new(new([]));// TODO
    }
}