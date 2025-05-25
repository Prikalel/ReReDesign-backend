namespace VelikiyPrikalel.ReReDesign.Application.Models;

/// <summary>
/// Результат проверки реакций.
/// </summary>
/// <param name="Reactions">Реакции.</param>
public record ReactionsResultApplication(List<UserReactionApplication> Reactions);