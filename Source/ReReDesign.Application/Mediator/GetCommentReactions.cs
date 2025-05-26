namespace VelikiyPrikalel.ReReDesign.Application.Mediator;

/// <summary>
/// Получить реакции на комментарии.
/// </summary>
public sealed class GetCommentReactions
{
    /// <summary>
    /// Запрос.
    /// </summary>
    /// <param name="CommentId">
    /// Идентификатор комментария в посте,
    /// на который хотим получить реакции.
    /// </param>
    public sealed record Query(string CommentId) : IRequest<GetReactionsResponseApplication>;

    /// <inheritdoc />
    public sealed class Handler(IDtfReactionsService dtfReactionsService) : IRequestHandler<Query, GetReactionsResponseApplication>
    {
        /// <inheritdoc />
        public async ValueTask<GetReactionsResponseApplication> Handle(Query request, CancellationToken cancellationToken) =>
            await dtfReactionsService.GetCommentReactions(request.CommentId, cancellationToken);
    }
}
