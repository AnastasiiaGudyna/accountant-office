using System;
using System.IO;
using System.Reflection;
using AccountantOffice.Core.Entities;
using AccountantOffice.Data.DBContext;
using AccountantOffice.Data.Repositories;
using AccountantOffice.UseCases.Cases;
using AccountantOffice.UseCases.Interfaces;
using AccountantOffice.UseCases.Mapper;
using IdentityModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;

namespace AccountantOffice.Api;

/// <summary>
/// Startup class
/// </summary>
public class Startup
{
    /// <summary>
    /// Startup Configuration field of type <see cref="IConfiguration"/>
    /// </summary>
    public IConfiguration Configuration { get; }
    private const string SpecificOrigins = "specificOrigins";
    private const string AuthenticationSchemeBearer = "Bearer";

    /// <summary>
    /// Startup constructor
    /// </summary>
    /// <param name="configuration">Startup Configuration</param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    /// Configure Services method
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    public void ConfigureServices(IServiceCollection services)
    {
        IdentityModelEventSource.ShowPII = true;
        var identityServerUrl = Configuration["IdentityServerUrl"];
        services.AddCors(options =>
        {
            options.AddPolicy(name: SpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
        });
        services.AddControllers();
        services.AddDbContext<AccountantContext>(opt => opt
            .UseLazyLoadingProxies()
            .UseNpgsql("name=ConnectionStrings:AccountantConnectionString")
        );
        services.AddTransient<IDepartmentBusinessCases, DepartmentBusinessCases>();
        services.AddTransient<IEmployeeBusinessCases, EmployeeBusinessCases>();
        services.AddTransient<CatalogBusinessCases>();
        services.AddTransient<IRepository<Department>, Repository<Department,AccountantContext>>();
        services.AddTransient<IRepository<Employee>, Repository<Employee,AccountantContext>>();
        services.AddTransient<ICatalogRepository, CatalogRepository>();
        services.AddAutoMapper(typeof(MapperProfile));
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "AccountantOffice.Api", Version = "v1" });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
        services
            .AddAuthentication(AuthenticationSchemeBearer)
            .AddJwtBearer(AuthenticationSchemeBearer, options =>
            {
                options.Authority = identityServerUrl;
                options.Audience = "accountant_office";
                options.TokenValidationParameters.ValidTypes = new[] { JwtClaimTypes.JwtTypes.AccessToken };
                //for docker 
                //System.InvalidOperationException: The MetadataAddress or Authority must use HTTPS unless disabled for development by setting RequireHttpsMetadata=false.
                //when request to identity server is made inside docker it doesn't need to be secure but error still happens 
                options.RequireHttpsMetadata = false;
            });
        services.AddAuthorization(AuthorizationPolicies.ConfigurePolicies);
    }

    /// <summary>
    /// Configure Method
    /// </summary>
    /// <param name="app"><see cref="IApplicationBuilder"/></param>
    /// <param name="env"><see cref="IWebHostEnvironment"/></param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors(SpecificOrigins);
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
                
        }
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AccountantOffice.Api v1"));
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints
                .MapControllers();
            //.RequireAuthorization();
        });
    }
}