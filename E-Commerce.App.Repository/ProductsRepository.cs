using E_Commerce.App.Core.Entities;
using E_Commerce.App.Infrastructure.Data;
using E_Commerce.App.Repository.Base;
using E_Commerce.App.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.App.Repository
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        private readonly StoreDbContext storeDbContext;
        public ProductsRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public async Task<IEnumerable<string>> GetBrandsAsync()
        {
            return await this.storeDbContext.Products.Select(x => x.Brand)
                .Distinct()
                .ToListAsync();
        }

        public Task<List<Product>> GetProductsAsync(string brand = null,
            string type = null, string sort = null)
        {
            var query = this.storeDbContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(brand))
            {
                query = query.Where(x => x.Brand == brand);
            }

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(x => x.Type == type);
            }

            if (!string.IsNullOrEmpty(sort))
            {
                query = sort switch
                {
                    "priceAsc" => query.OrderBy(x => x.Price),
                    "priceDesc" => query.OrderByDescending(x => x.Price),
                    _ => query.OrderBy(x => x.Name),
                };
            }

            return query.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetTypesAsync()
        {
            return await this.storeDbContext.Products.Select(x => x.Type)
                .Distinct()
                .ToListAsync();
        }
    }
}
