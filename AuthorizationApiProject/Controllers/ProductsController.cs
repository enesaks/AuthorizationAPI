using AuthorizationApiProject.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AuthorizationApiProject.Controllers
{
    [Authorize(Roles = "ROOT, DEVELOPER")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AuthorizationApiContext _context;

        public ProductsController(AuthorizationApiContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        [Authorize(Roles = "ROOT, DEVELOPER")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        [Authorize(Roles = "ROOT, DEVELOPER")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }


        // POST: api/products
        [HttpPost]
        [Authorize(Roles = "ROOT")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ROOT")]
        public async Task<IActionResult> PutProduct(int id, Product updatedProduct)
        {
            var existingProduct = await _context.Products.FindAsync(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/products/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ROOT")]
        public async Task<IActionResult> DeleteProduct(int id)
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

    }
}
