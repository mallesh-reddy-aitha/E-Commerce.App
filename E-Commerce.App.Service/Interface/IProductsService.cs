using E_Commerce.App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.App.Service.Interface
{
    public interface IProductsService
    {

        /// <summary>
        /// Create product record.
        /// </summary>
        /// <param name="product">product.</param>
        void CreateProduct(Product product);

        void DeleteProduct(Product product);

        Task<IEnumerable<string>> GetBrandsAsync();

        Task<Product> GetProductByIdAsync(long id);
        /// <summary>
        /// Get all product records.
        /// </summary>
        /// <returns>List of products.</returns>
        Task<List<Product>> GetProductsAsync();

        Task<List<Product>> GetProductsAsync(string brand = null,
            string type = null, string sort = null);

        Task<IEnumerable<string>> GetTypesAsync();

        bool ProductExist(long id);

        Task<bool> SaveChangesAsync();

        void UpdateProduct(Product product);
    }
}
