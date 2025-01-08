using E_Commerce.App.Core.Entities;
using E_Commerce.App.Infrastructure.Data;
using E_Commerce.App.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.App.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly StoreDbContext storeDbContext;
        public ProductsRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            product.CreatedBy = product.ModifiedBy = Guid.NewGuid();
            product.CreatedOn = product.ModifiedOn = DateTime.UtcNow;
            this.storeDbContext.Add(product);
            await this.storeDbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(Product product)
        {
            this.storeDbContext.Remove(product);
            await this.storeDbContext.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(long id)
        {
            return await this.storeDbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await this.storeDbContext.Products.ToListAsync();
        }

        public async Task<bool> ProductExist(long id)
        {
            return await this.storeDbContext.Products.AnyAsync(x => x.Id == id);
        }

        public async Task UpdateProduct(Product product)
        {
            this.storeDbContext.Entry(product).State = EntityState.Modified;
            await this.storeDbContext.SaveChangesAsync();
        }
    }
}
