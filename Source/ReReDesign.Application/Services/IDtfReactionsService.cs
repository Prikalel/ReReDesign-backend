﻿namespace VelikiyPrikalel.ReReDesign.Application.Services;

/// <summary>
/// Реакции дтф.
/// </summary>
public interface IDtfReactionsService
{
    /// <summary>
    /// Реакции на комментарии.
    /// </summary>
    /// <param name="commentId">Идентификатор комментария.</param>
    /// <param name="cancellation">Токен отмены.</param>
    /// <returns><see cref="GetReactionsResponseApplication"/>.</returns>
    Task<GetReactionsResponseApplication> GetCommentReactions(string commentId, CancellationToken cancellation);

    /// <summary>
    /// Реакции на пост.
    /// </summary>
    /// <param name="postId">Идентификатор поста.</param>
    /// <param name="cancellation">Токен отмены.</param>
    /// <returns><see cref="GetReactionsResponseApplication"/>.</returns>
    Task<GetReactionsResponseApplication> GetPostReactions(string postId, CancellationToken cancellation);
}
