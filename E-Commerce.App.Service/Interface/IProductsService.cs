using E_Commerce.App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.App.Service.Interface
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(long id);
        Task<Product> CreateProduct(Product product);
        Task<bool> ProductExist(long id);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);
    }
}
