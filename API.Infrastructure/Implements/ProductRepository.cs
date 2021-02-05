using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Implements
{

    public class ProductRepository : IProductRepository
    {
        private readonly DemiralpContext _demiralpContext;
        public ProductRepository(DemiralpContext demiralpContext)
        {
            _demiralpContext = demiralpContext;
        }


        //public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        //{
        //    return await _demiralpContext.ProductBrands.ToListAsync();
        //}

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _demiralpContext.Products
                //.Include(p=>p.ProductBrand)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _demiralpContext.Products
                .Include(p => p.ProductType.Id)
                //  .Include(p=>p.ProductBrand.Id)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _demiralpContext.ProductTypes.ToListAsync();
        }
    }
}
