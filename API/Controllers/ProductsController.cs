using API.Infrastructure.DataContext;
using API.Core.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product>  _genericRepositoryProduct;
        private readonly IGenericRepository<ProductBrand> _genericRepositoryProductBrand;
        private readonly IGenericRepository<ProductType> _genericRepositoryProductType;
        public ProductsController(IGenericRepository<Product> genericRepositoryProduct,
            IGenericRepository<ProductBrand> genericRepositoryProductBrand, 
            IGenericRepository<ProductType> genericRepositoryProductType)
        {
            _genericRepositoryProduct = genericRepositoryProduct;
            _genericRepositoryProductBrand = genericRepositoryProductBrand;
            _genericRepositoryProductType = genericRepositoryProductType;
        }
        /// <summary>
        /// Tüm Ürünleri Listeler
        /// </summary>
        /// <returns></returns>
        [HttpGet]
         public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var data = await _genericRepositoryProduct.ListAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> ProductSingle(int id)
        {
            var data = await _genericRepositoryProduct.GetByIdAsync(id);

            return Ok(data);

        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> ProductBrands()
        {
            var data = await _genericRepositoryProductBrand.ListAllAsync();

            return Ok(data);

        }
        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> ProductTypes()
        {
            var data = await _genericRepositoryProductType.ListAllAsync();

            return Ok(data);

        }

    }
}
