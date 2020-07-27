using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductController:ControllerBase
    {
        private readonly StoreDbContext _storeContext;
        public ProductController(StoreDbContext storeContext)
        {
            this._storeContext = storeContext;
        }
        [HttpGet("v1/products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _storeContext.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet("v1/products/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _storeContext.Products.FindAsync(id);
            return Ok(product);
        }
        
        
    }
}