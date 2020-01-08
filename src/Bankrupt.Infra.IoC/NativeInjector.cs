﻿using Bankrupt.Application.Interface;
using Bankrupt.Application.Service;
using Bankrupt.Data.Model.Interface;
using Bankrupt.Data.Model.Repository;
using Bankrupt.Data.UoW;
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

            // DataBase
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IBoardGameRepository, BoardGameRepository>();
            services.AddScoped<IBoardHouseRepository, BoardHouseRepository>();
            services.AddScoped<IPossesionRepository, PossesionRepository>();
        }
    }
}