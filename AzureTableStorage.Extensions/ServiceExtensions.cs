using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureTableStorage.Extensions
{
    /// <summary>
    /// Creating Easy plugin
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Add Table Storage Service in Service pipeline, with Extra Configurations
        /// </summary>
        /// <param name="setupOptions">Options to configure</param>
        /// <param name="serviceLifetime">ServiceLifetime, optional by default Scoped</param>
        public static void AddTableStorageServices(this IServiceCollection services,
                                                    Action<AzureTableClientOptions> setupOptions, 
                                                    ServiceLifetime serviceLifetime=ServiceLifetime.Scoped )
        {
            services.Configure<AzureTableClientOptions>(setupOptions);
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton<IAzureTableClient>(provider =>
                    {
                        var options = provider.GetRequiredService<IOptions<AzureTableClientOptions>>();
                        return new AzureTableClient(options.Value);
                    });
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped<IAzureTableClient>(provider =>
                    {
                        var options = provider.GetRequiredService<IOptions<AzureTableClientOptions>>();
                        return new AzureTableClient(options.Value);
                    });
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient<IAzureTableClient>(provider =>
                    {
                        var options = provider.GetRequiredService<IOptions<AzureTableClientOptions>>();
                        return new AzureTableClient(options.Value);
                    });
                    break;
            }
        }
    }
}
