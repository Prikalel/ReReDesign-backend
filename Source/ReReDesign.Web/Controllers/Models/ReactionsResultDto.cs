namespace VelikiyPrikalel.ReReDesign.Web.Controllers.Models;

/// <summary>
/// Результат проверки реакций.
/// </summary>
/// <param name="Reactions">Реакции.</param>
public record ReactionsResultDto(List<UserReactionDto> Reactions);