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

        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    await this.productsRepository.CreateProduct(product);
                }

                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteProduct(Product product)
        {
            try
            {
                await this.productsRepository.DeleteProduct(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetProductById(long id)
        {
            try
            {
                if (id > 0)
                {
                    return await this.productsRepository.GetProductById(id);
                }

                return new Product();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                return await this.productsRepository.GetProducts();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ProductExist(long id)
        {
            try
            {
                return await this.productsRepository.ProductExist(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateProduct(Product product)
        {
            try
            {
                await this.productsRepository.UpdateProduct(product);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
