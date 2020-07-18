using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            return prod;
        }
    }
}