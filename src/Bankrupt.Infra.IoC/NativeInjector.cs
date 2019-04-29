using Bankrupt.Application.Interface;
using Bankrupt.Application.Service;
using Bankrupt.Domain;
using Bankrupt.Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Bankrupt.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();        

            // Application
            services.AddScoped<IGameService, GameService>();

            // Domain - Commands
            services.AddScoped<IPlayerDomain, PlayerDomain>();
            services.AddScoped<IGameDomain, GameDomain>();
        }
    }
}