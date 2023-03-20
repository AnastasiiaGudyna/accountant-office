using IdentityServer.Api.Extensions;

namespace IdentityServer.Api;

public class Startup
{
    /// <summary>
    /// Startup Configuration field of type <see cref="IConfiguration"/>
    /// </summary>
    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Environment { get; }
    private const string SpecificOrigins = "specificOrigins";

    /// <summary>
    /// Startup constructor
    /// </summary>
    /// <param name="configuration">Startup Configuration</param>
    /// <param name="environment"><see cref="IWebHostEnvironment"/></param>
    public Startup(IWebHostEnvironment environment, IConfiguration configuration)
    {
        Configuration = configuration;
        Environment = environment;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: SpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
        });
        services.AddRazorPages();
        services.ConfigureIdentityServer(Environment, Configuration);
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        //loggerFactory.AddConsole(LogLevel.Debug);
        app.UseCors(SpecificOrigins);
        app
            .UseStaticFiles()
            .UseRouting()
            .UseDeveloperExceptionPage()
            .UseIdentityServer()
            .UseAuthorization()
            .UseEndpoints(endpoints =>
            {
                endpoints
                    .MapRazorPages()
                    .RequireAuthorization();
            });
    }
}