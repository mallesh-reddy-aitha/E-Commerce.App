using E_Commerce.App.Core.Entities;
using E_Commerce.App.Infrastructure.Data;
using E_Commerce.App.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;
        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await this.productsService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id:long}")] // api/Products/1
        public async Task<ActionResult<Product>> GetProductById(long id)
        {
            var product = await this.productsService.GetProductById(id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            return await this.productsService.CreateProduct(product);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateProduct(long id,Product product)
        {
            if(product.Id!=id||!await this.productsService.ProductExist(id))
            {
                return BadRequest("Cannot update this product");
            }

            await this.productsService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> UpdateProduct(long id)
        {
            var product = await this.productsService.GetProductById(id);
            if (product == null)
            {
                return NotFound("Cannot find this product");
            }

            await this.productsService.DeleteProduct(product);
            return NoContent();
        }
    }
}
