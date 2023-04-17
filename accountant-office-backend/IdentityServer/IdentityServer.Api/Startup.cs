using IdentityServer.Api.Extensions;
using IdentityServer.Api.Services;
using IdentityServer.Data.DbContexts;
using IdentityServer.Data.Mapping;
using IdentityServer.Data.Models;
using Microsoft.EntityFrameworkCore;

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
        // services.AddDbContext<ConfigurationDataContext>(opt =>
        // {
        //     opt
        //         .UseLazyLoadingProxies()
        //         .UseNpgsql("name=ConnectionStrings:EntityServerConnectionString");
        //     
        // });
        services.AddDbContext<OperationalDataContext>(opt =>
        {
            opt
                .UseLazyLoadingProxies()
                .UseNpgsql("name=ConnectionStrings:IdentityServerConnectionString");
            
        });
        services.AddRazorPages();
        services.ConfigureIdentityServer(Environment, Configuration);
        services.AddAutoMapper(typeof(MapperProfile));
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
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

        var serviceProvider = app.ApplicationServices;
        using var scope = serviceProvider.CreateScope();
        var userService = scope.ServiceProvider.GetService<UserService>();
        if(userService.FindByUsernameAsync("example@example.com").Result is null)
        {
            var admin = new User
            {
                Email = "example@example.com",
                FirstName = "Admin",
                LastName = "Admin",
                PasswordHash = "Admin"
            };
            var user = userService.CreateUserAsync(admin).Result;
            Console.WriteLine(user);
        }
    }
}