﻿namespace VelikiyPrikalel.ReReDesign.Infrastructure;

/// <summary>
/// Extension методы <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрирует конфиги инфраструктуры.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/>.</param>
    /// <param name="configuration">><see cref="IConfiguration"/>.</param>
    public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        /* uncomment to register Database

          services.AddDbContext<ReReDesignContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("ReReDesign"));
            });
        */

        services.RegisterSettings<DtfLoginSettings>(configuration);

        services.Scan(scan => scan
            .FromAssemblyOf<ReReDesignContext>()
            .AddClasses(classes =>
                classes.InNamespaces(
                    "VelikiyPrikalel.ReReDesign.Infrastructure.Repositories",
                    "VelikiyPrikalel.ReReDesign.Infrastructure.Services"))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }

    private static void RegisterSettings<TSettings>(this IServiceCollection services, IConfiguration configuration)
        where TSettings : class =>
        services.Configure<TSettings>(
            configuration.GetSection(typeof(TSettings).Name));
}