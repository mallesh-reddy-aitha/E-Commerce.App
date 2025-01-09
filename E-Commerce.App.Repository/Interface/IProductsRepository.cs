using E_Commerce.App.Core.Entities;
using E_Commerce.App.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.App.Repository.Interface
{
    public interface IProductsRepository: IGenericRepository<Product>
    {
        Task<IEnumerable<string>> GetBrandsAsync();

        Task<List<Product>> GetProductsAsync(string brand = null,
            string type = null, string sort = null);

        Task<IEnumerable<string>> GetTypesAsync();
    }
}
