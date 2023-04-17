using IdentityServer.Api;
using IdentityServer.Api.Services;
using IdentityServer.Data.Models;
using Microsoft.AspNetCore.Identity;

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
    .Build()
    .Run();