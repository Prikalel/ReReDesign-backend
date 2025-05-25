namespace VelikiyPrikalel.ReReDesign.Web.Controllers.Models;

/// <summary>
/// Проставление пользователем реакции.
/// </summary>
/// <param name="User">Пользователь.</param>
/// <param name="ReactionId">Id реакции, которую он поставил на пост/коммент.</param>
public record UserReactionDto(DtfUserDto User, int ReactionId);
