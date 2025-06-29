namespace VelikiyPrikalel.ReReDesign.Application.Models;

/// <summary>
/// Пользователь dtf.
/// </summary>
/// <param name="Id">Id.</param>
/// <param name="Name">Имя.</param>
/// <param name="Avatar">Аватар пользователя.</param>
public record DtfUserApplication(int Id, string Name, DtfAvatarApplication Avatar);
