namespace VelikiyPrikalel.ReReDesign.Web;

/// <summary>
/// Класс конфигурации веб-приложения.
/// </summary>
public class Startup
{
    private const string ServiceName = "ReReDesign";

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="configuration">Конфигурация.</param>
    /// <param name="env">Параметры окружения.</param>
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        Environment = env;
    }

    /// <summary>
    /// Конфигурация приложения.
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// Окружение.
    /// </summary>
    public IWebHostEnvironment Environment { get; }

    private ServicesRegistrationSettings ServicesRegistrationOptions
    {
        get
        {
            ServicesRegistrationSettings settings = new();
            Configuration.GetSection(nameof(ServicesRegistrationSettings))
                .Bind(settings);
            return settings;
        }
    }

    /// <summary>
    /// Конфигурирует pipeline запросов.
    /// </summary>
    /// <param name="app">Строитель приложения.</param>
    /// <param name="env">Параметры окружения.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDeveloperExceptionPage();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        if (ServicesRegistrationOptions.RegisterSwagger)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{ServiceName} API v1");
            });
        }
    }

    /// <summary>
    /// Конфигурирует все сервисы приложения.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.RegisterInfrastructure(Configuration);

        if (ServicesRegistrationOptions.RegisterSwagger)
        {
            RegisterSwagger(services);
        }
        services.AddControllers();

        services.AddMediator((MediatorOptions options) =>
            options.ServiceLifetime = ServiceLifetime.Scoped);

        services.AddMemoryCache();
        services.AddSingleton<IAsyncCacheProvider, Polly.Caching.Memory.MemoryCacheProvider>();
        // RegisterCachePolicyWithName<string>(services, "myCachePolicy", 5);
    }

    private static void RegisterSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            IncludeReReDesignXmlDocs(options, nameof(Web));

            options.SupportNonNullableReferenceTypes();
            options.UseAllOfForInheritance();

            options.EnableAnnotations();
        });
    }

    private static void IncludeReReDesignXmlDocs(SwaggerGenOptions swaggerGenOptions, string projectName)
    {
        string xmlDocsPath = Path.Combine(AppContext.BaseDirectory, $"{nameof(VelikiyPrikalel)}.{nameof(ReReDesign)}.{projectName}.xml");
        swaggerGenOptions.IncludeXmlComments(xmlDocsPath);
    }

    private static void RegisterCachePolicyWithName<TCacheElement>(
        IServiceCollection services,
        string name,
        int ttlMinutes) =>
        services.AddSingleton<IReadOnlyPolicyRegistry<string>, PolicyRegistry>((serviceProvider) =>
        {
            PolicyRegistry registry = new();
            registry.Add(name,
                Policy.CacheAsync<TCacheElement>(
                    serviceProvider
                        .GetRequiredService<IAsyncCacheProvider>()
                        .AsyncFor<TCacheElement>(),
                    TimeSpan.FromMinutes(ttlMinutes)));
            return registry;
        });
}