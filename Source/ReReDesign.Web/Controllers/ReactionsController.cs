namespace VelikiyPrikalel.ReReDesign.Web.Controllers;

/// <summary>
/// Контроллер для проверки реакций пользователей.
/// </summary>
[Route("v1/[controller]")]
[ApiController]
public class ReactionsController(
    ILogger<ReactionsController> logger,
    IMapper mapper,
    IMediator mediator) : Controller
{
    /// <summary>
    /// Получить реакции на комментарий в посте <paramref name="postId"/>.
    /// </summary>
    /// <param name="postId">Идентификатор поста, комментарий которого проверяем.</param>
    /// <param name="commentId">Идентификатор комментария в посте <paramref name="postId"/>,
    /// на который хотим получить реакции.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns><see cref="GetReactionsResponseDto"/>.</returns>
    [HttpGet("/comment")]
    public async Task<GetReactionsResponseDto> GetCommentReactions(
        [FromQuery] string postId,
        [FromQuery] string commentId,
        CancellationToken cancellationToken)
    {
        GetReactionsResponseApplication queryResponse = await mediator
            .Send(new GetCommentReactions.Query(postId, commentId), cancellationToken);

        GetReactionsResponseDto responseDto = mapper.Map<GetReactionsResponseDto>(queryResponse);

        logger.LogInformation("Get reactions for comment {Id} returned {Count} results",
            commentId,
            responseDto.Result.Reactions.Count);

        return responseDto;
    }
}