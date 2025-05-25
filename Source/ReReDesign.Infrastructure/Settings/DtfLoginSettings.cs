namespace VelikiyPrikalel.ReReDesign.Infrastructure.Settings;

/// <summary>
/// Настройки входа в dtf.
/// Аккаунт должен обладать подпиской dtf-плюс.
/// </summary>
public class DtfLoginSettings
{
    /// <summary>
    /// Почта.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
