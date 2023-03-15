using IdentityServer.Api.Extensions;

namespace IdentityServer.Api;

public class Startup
{
    /// <summary>
    /// Startup Configuration field of type <see cref="IConfiguration"/>
    /// </summary>
    public IConfiguration Configuration { get; }
    private const string SpecificOrigins = "specificOrigins";
    
    /// <summary>
    /// Startup constructor
    /// </summary>
    /// <param name="configuration">Startup Configuration</param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
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
        services.ConfigureIdentityServer(Configuration);
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