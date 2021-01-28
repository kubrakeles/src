using API.Data.DataContext;
using API.Data.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _storeContext;
        public ProductsController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        [HttpGet]
         public ActionResult<List<Product>> GetProducts()
        {
            var data = _storeContext.Products.ToList();
            return data;
        }
        [HttpGet("{id}")]
        public ActionResult<Product> ProductGET(int id)
        {
            var data = _storeContext.Products.Find(id);

            return data;

        }
    }
}
