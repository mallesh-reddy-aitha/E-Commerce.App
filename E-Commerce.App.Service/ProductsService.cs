using E_Commerce.App.Core.Entities;
using E_Commerce.App.Repository.Interface;
using E_Commerce.App.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce.App.Service
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productsRepository;
        public ProductsService(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public void CreateProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    this.productsRepository.Add(product);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                this.productsRepository.Remove(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetBrandsAsync()
        {
            try
            {
                return await this.productsRepository.GetBrandsAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetProductByIdAsync(long id)
        {
            try
            {
                if (id > 0)
                {
                    return await this.productsRepository.GetByIdAsync(id);
                }

                return new Product();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                return await this.productsRepository.GetProductsAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Product>> GetProductsAsync(string brand = null,
            string type = null, string sort = null)
        {
            try
            {
                return await this.productsRepository.GetProductsAsync(brand, type);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetTypesAsync()
        {
            try
            {
                return await this.productsRepository.GetTypesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ProductExist(long id)
        {
            try
            {
                return this.productsRepository.Exist(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await this.productsRepository.SaveAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                this.productsRepository.Update(product);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
