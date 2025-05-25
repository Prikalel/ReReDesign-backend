namespace VelikiyPrikalel.ReReDesign.Application.Mediator;

/// <summary>
/// Получить реакции на комментарии.
/// </summary>
public sealed class GetCommentReactions
{
    /// <summary>
    /// Запрос.
    /// </summary>
    /// <param name="PostId">Идентификатор поста, комментарий которого проверяем.</param>
    /// <param name="CommentId">
    /// Идентификатор комментария в посте <paramref name="PostId"/>,
    /// на который хотим получить реакции.
    /// </param>
    public sealed record Query(string PostId, string CommentId) : IRequest<GetReactionsResponseApplication>;

    /// <inheritdoc />
    public sealed class Handler() : IRequestHandler<Query, GetReactionsResponseApplication>
    {
        /// <inheritdoc />
        public async ValueTask<GetReactionsResponseApplication> Handle(Query request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return new(new([new(new(12, "name"), 12313)])); // TODO
        }
    }
}
