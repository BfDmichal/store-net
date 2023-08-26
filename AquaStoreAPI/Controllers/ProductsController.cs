using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace AquaStoreAPI.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreDbContext _dbContext;

        public ProductsController(StoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<Product> GetProducts()
        {
            var products = _dbContext.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Product>> GetProduct([FromRoute] int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            return Ok(product);
        }
    }
}
