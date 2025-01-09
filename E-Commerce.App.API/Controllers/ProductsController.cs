using E_Commerce.App.Core.Entities;
using E_Commerce.App.Infrastructure.Data;
using E_Commerce.App.Repository.Interface;
using E_Commerce.App.Repository.Specifications;
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
        private readonly IProductsRepository productsRepository;

        public ProductsController(IProductsService productsService,
            IProductsRepository productsRepository)
        {
            this.productsService = productsService;
            this.productsRepository = productsRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            this.productsService.CreateProduct(product);
            if (await this.productsService.SaveChangesAsync())
            {
                return CreatedAtAction("GetProductById", new { id = product.Id }, product);
            }

            return BadRequest("Problem creatin product");
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<string>>> GetBrands()
        {
            var specification = new BrandSpecification();
            return Ok(await this.productsRepository.ListAsync(specification));
        }

        [HttpGet("{id:long}")] // api/Products/1
        public async Task<ActionResult<Product>> GetProductById(long id)
        {
            var product = await this.productsService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] string brand = null,
            [FromQuery] string type = null, [FromQuery] string sort = null)
        {
            var specification = new ProductSpecification(brand, type, sort);
            var products = await this.productsRepository.ListAsync(specification);
            return Ok(products);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<string>>> GetTypes()
        {
            var specification = new TypeSpecification();
            return Ok(await this.productsRepository.ListAsync(specification));
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> UpdateProduct(long id)
        {
            var product = await this.productsService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Cannot find this product");
            }

            this.productsService.DeleteProduct(product);

            if (await this.productsService.SaveChangesAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem deleting the product");
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateProduct(long id, Product product)
        {
            if (product.Id != id || !this.productsService.ProductExist(id))
            {
                return BadRequest("Cannot update this product");
            }

            this.productsService.UpdateProduct(product);
            if (await this.productsService.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest("Problem updating the product");
        }
    }
}
