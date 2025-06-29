namespace VelikiyPrikalel.ReReDesign.Web.Controllers.Models;

/// <summary>
/// Пользователь dtf.
/// </summary>
/// <param name="Id">Id.</param>
/// <param name="Name">Имя.</param>
/// <param name="Avatar">Аватар пользователя.</param>
public record DtfUserDto(int Id, string Name, DtfAvatarDto Avatar);
