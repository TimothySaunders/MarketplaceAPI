using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarketplaceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.Controllers
{
    [Route("v1")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: products
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: product/id
        [HttpGet("product/{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var Product = await _context.Products.FindAsync(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Product;
        }

    }
}
