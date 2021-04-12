using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;

namespace API.Controllers
{
    [Route("api/[Controller]")]
    public class ProductController:ControllerBase
    {

      private readonly StoreContext _storeContext;
       public ProductController(StoreContext StoreContext)
       {
           this._storeContext = StoreContext;
       }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await  _storeContext.Products.ToListAsync();
            return Ok(products);
        }

        
        [HttpGet("{id:int}")]
        
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            return  await _storeContext.Products.FindAsync(id);
        }
    }
}