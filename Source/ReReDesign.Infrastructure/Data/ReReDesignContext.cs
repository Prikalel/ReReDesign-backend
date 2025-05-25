namespace VelikiyPrikalel.ReReDesign.Infrastructure.Data;

/// <summary>
/// Контекст БД.
/// </summary>
public class ReReDesignContext : DbContext
{
    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="options"><see cref="DbContextOptions"/>.</param>
    public ReReDesignContext(DbContextOptions<ReReDesignContext> options)
        : base(options)
    {
    }
}