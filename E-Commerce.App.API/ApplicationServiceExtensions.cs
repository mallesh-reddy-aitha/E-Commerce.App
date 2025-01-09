using E_Commerce.App.Repository;
using E_Commerce.App.Repository.Base;
using E_Commerce.App.Repository.Interface;
using E_Commerce.App.Service;
using E_Commerce.App.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace E_Commerce.App.API
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();
        }
    }
}
