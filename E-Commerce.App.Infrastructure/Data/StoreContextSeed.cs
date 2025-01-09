using E_Commerce.App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.App.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(string[] args, IHost host)
        {
            using var serviceScope = host.Services.CreateScope();
            var services = serviceScope.ServiceProvider;
            //var seedConfiguration = configuration.GetSection(ConfigDefaults.SeedConfiguration).Value;
            using var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = services.GetRequiredService<StoreDbContext>();
            await context.Database.MigrateAsync();
            if (!context.Products.Any())
            {
                var productionData = await File.ReadAllTextAsync("../E-Commerce.App.Infrastructure/Data/SeedData/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productionData);

                if (products == null) return;

                context.Products.AddRange(products);

                await context.SaveChangesAsync();
            }
        }
    }
}
