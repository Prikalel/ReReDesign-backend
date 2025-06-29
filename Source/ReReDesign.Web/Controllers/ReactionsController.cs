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
    /// Получить реакции на комментарий в посте.
    /// </summary>
    /// <param name="commentId">Идентификатор комментария в посте,
    /// на который хотим получить реакции.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns><see cref="GetReactionsResponseDto"/>.</returns>
    [HttpGet("/comment")]
    public async Task<GetReactionsResponseDto> GetCommentReactions(
        [FromQuery] string commentId,
        CancellationToken cancellationToken)
    {
        GetReactionsResponseApplication queryResponse = await mediator
            .Send(new GetCommentReactions.Query(commentId), cancellationToken);

        GetReactionsResponseDto responseDto = mapper.Map<GetReactionsResponseDto>(queryResponse);

        logger.LogInformation("Get reactions for comment {Id} returned {Count} results",
            commentId,
            responseDto.Result.Reactions.Count);

        return responseDto;
    }

    /// <summary>
    /// Получить реакции на пост.
    /// </summary>
    /// <param name="postId">Идентификатор поста,
    /// на который хотим получить реакции.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns><see cref="GetReactionsResponseDto"/>.</returns>
    [HttpGet("/post")]
    public async Task<GetReactionsResponseDto> GetPostReactions(
        [FromQuery] string postId,
        CancellationToken cancellationToken)
    {
        GetReactionsResponseApplication queryResponse = await mediator
            .Send(new GetPostReactions.Query(postId), cancellationToken);

        GetReactionsResponseDto responseDto = mapper.Map<GetReactionsResponseDto>(queryResponse);

        logger.LogInformation("Get reactions for post {Id} returned {Count} results",
            postId,
            responseDto.Result.Reactions.Count);

        return responseDto;
    }
}