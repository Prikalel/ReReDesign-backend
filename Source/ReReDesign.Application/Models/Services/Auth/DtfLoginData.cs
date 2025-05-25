namespace VelikiyPrikalel.ReReDesign.Application.Models.Services.Auth;

/// <summary>
/// Данные о выполненном входе.
/// </summary>
/// <param name="Type">Тип.</param>
/// <param name="AccessToken">Токен доступа.</param>
/// <param name="AccessExpTimestamp">Время жизни токена.</param>
/// <param name="RefreshToken">Токен для Перезарядки.</param>
/// <param name="RefreshExpTimestamp">Время жизни токена для перезарядки.</param>
public record DtfLoginData(
    string Type,
    string AccessToken,
    long AccessExpTimestamp,
    string RefreshToken,
    long RefreshExpTimestamp);
