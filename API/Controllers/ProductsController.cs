using API.Infrastructure.DataContext;
using API.Core.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core.Interfaces;
using API.Core.Specifications;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
   
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product>  _genericRepositoryProduct;
        private readonly IGenericRepository<ProductImage> _genericRepositoryImage;
        private readonly IGenericRepository<ProductType> _genericRepositoryProductType;
    
        public ProductsController(IGenericRepository<Product> genericRepositoryProduct,
            IGenericRepository<ProductType> genericRepositoryProductType,IGenericRepository<ProductImage> genericImage)
        {
            _genericRepositoryProduct = genericRepositoryProduct;
            _genericRepositoryProductType = genericRepositoryProductType;
            _genericRepositoryImage = genericImage;

        }
        /// <summary>
        /// Tüm Ürünleri Listeler
        /// </summary>
        /// <returns></returns>
        [HttpGet]
         public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var spec = new ProductsWithBrandAndTypeSpecification();
            var data = await _genericRepositoryProduct.ListAsync(spec);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> ProductSingle(int id)
        {
            var spec = new ProductsWithBrandAndTypeSpecification(id);
            var data = await _genericRepositoryProduct.GetEntityWithSpec(spec);
            return Ok(data);
        }
        [HttpPost(template: "Add")]
        public ActionResult AddProduct(Product product)
        {
            var result = _genericRepositoryProduct.add(product);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPost(template: "Update")]
        public ActionResult UpdateProduct(Product product)
        {
            var result = _genericRepositoryProduct.update(product);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> ProductTypes()
        {
            var data = await _genericRepositoryProductType.ListAllAsync();
            return Ok(data);
        }

        [HttpPost(template: "Images")]
        public ActionResult AddImages(ProductImage image)
        {
            var result = _genericRepositoryImage.add(image);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

    }
}
