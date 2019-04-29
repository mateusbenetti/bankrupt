using Microsoft.Extensions.DependencyInjection;
using System;
using  AutoMapper;
using Bankrupt.Application.Mapper;

namespace Bankrupt.Mvc.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddAutoMapper();
            AutoMapperConfig.RegisterMappings();
        }
    }
}
