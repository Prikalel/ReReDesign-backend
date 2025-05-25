namespace VelikiyPrikalel.ReReDesign.Application.Models.Services.Auth;

/// <summary>
/// Результат выполненного входа.
/// </summary>
/// <param name="Message">Сообщение о результате.</param>
/// <param name="Data">Данные.</param>
public record DtfLoginResult(string Message, DtfLoginData Data);
