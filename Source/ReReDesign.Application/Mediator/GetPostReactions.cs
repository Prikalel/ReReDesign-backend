namespace VelikiyPrikalel.ReReDesign.Application.Mediator;

/// <summary>
/// Получить реакции на пост.
/// </summary>
public sealed class GetPostReactions
{
    /// <summary>
    /// Запрос.
    /// </summary>
    /// <param name="PostId">
    /// Идентификатор поста,
    /// на который хотим получить реакции.
    /// </param>
    public sealed record Query(string PostId) : IRequest<GetReactionsResponseApplication>;

    /// <inheritdoc />
    public sealed class Handler(IDtfReactionsService dtfReactionsService) : IRequestHandler<Query, GetReactionsResponseApplication>
    {
        /// <inheritdoc />
        public async ValueTask<GetReactionsResponseApplication> Handle(Query request, CancellationToken cancellationToken) =>
            await dtfReactionsService.GetPostReactions(request.PostId, cancellationToken);
    }
}
