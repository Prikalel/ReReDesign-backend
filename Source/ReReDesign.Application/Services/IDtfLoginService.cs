namespace VelikiyPrikalel.ReReDesign.Application.Services;

/// <summary>
/// Сервис для логина на dtf.
/// </summary>
public interface IDtfLoginService
{
    /// <summary>
    /// Выполнить вход в систему.
    /// </summary>
    /// <returns>Результат.</returns>
    Task<DtfLoginResult> Login(CancellationToken cancellation);
}
