using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repository.GetProductsAsync();

            return Ok(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var products = await _repository.GetProductBrandsAsync();

            return Ok(products);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var products = await _repository.GetProductTypesAsync();

            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            var prod = await _repository.GetProductByIdAsync(productId);
            return prod;
        }
    }
}