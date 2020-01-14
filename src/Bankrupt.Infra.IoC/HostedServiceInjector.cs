using Bankrupt.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bankrupt.CrossCutting.IoC
{
    public static class HostedServiceInjector
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<TimedHostedService>();
            services.AddHostedService<ConsumeScopedServiceHostedService>();
            services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
            services.AddHostedService<QueuedHostedService>();
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
        }
    }
}
