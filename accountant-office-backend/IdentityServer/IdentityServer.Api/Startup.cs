using IdentityServer.Api.Extensions;

namespace IdentityServer.Api;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureIdentityServer();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        //loggerFactory.AddConsole(LogLevel.Debug);
        app
            .UseDeveloperExceptionPage()
            .UseIdentityServer();
    }
}