using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ivao.It.WhazzupData.SDK
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds and configures an <see cref="IHttpClientFactory"/> for IVAO Whazzup v2 API Calls
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddIvaoWhazzupHttpClient(this IServiceCollection services, IvaoDataOptions options)
        {
            services.AddHttpClient(options.WhazzupHttpClientName, opt =>
            {
                opt.BaseAddress = new Uri(options.WhazzupUrl);
            });

            
            services.Configure<IvaoDataOptions>(opt =>
            {
                opt.WhazzupUrl = options.WhazzupUrl;
                opt.WhazzupHttpClientName = options.WhazzupHttpClientName;
                opt.ReadEvery = options.ReadEvery;
            });
            services.TryAddSingleton<IIvaoData, IvaoData>();

            return services;
        }
    }
}
