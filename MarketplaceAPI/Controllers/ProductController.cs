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

        // GET: /products
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return products.Select(product => ProductToDTO(product)).ToArray();
        }

        // GET: /product/id
        [HttpGet("product/{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return ProductToDTO(product);
        }

        // POST: /product
        [HttpPost("product")]
        public async Task<ActionResult<ProductDTO>> PostProduct([FromForm]ProductDTO dtoProduct)
        {
            var product = DTOToProduct(dtoProduct);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(ProductToDTO(product));
        }

        // PUT: /products/{id}
        [HttpPut("Product/{id}")]
        public async Task<IActionResult> PutProduct(long id, [FromForm] ProductDTO dtoProduct)
        {
            if (ProductExists(id))
            {
                var product = await _context.Products.FindAsync(id);
                product.Name = dtoProduct.Name ?? product.Name;
                product.Price = (dtoProduct.Price == null) ? product.Price : decimal.Parse(dtoProduct.Price);

                _context.Entry(product).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: product/{id}
        [HttpDelete("Prodcut/{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(product => product.Id == id);
        }

        private ProductDTO ProductToDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.ToString()
            };
        }

        private Product DTOToProduct(ProductDTO dtoProduct)
        {
            return new Product
            {
                Id = dtoProduct.Id,
                Name = dtoProduct.Name,
                Price = decimal.Parse(dtoProduct.Price)
            };
        }
    }
}
