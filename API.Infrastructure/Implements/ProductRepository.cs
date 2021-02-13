using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Core.Utilities.Result;
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

        public IResult add(Product Entity)
        {
            throw new NotImplementedException();
        }

        public IResult delete(Product Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetEntityWithSpec(ISpecification<Product> spec)
        {
            throw new NotImplementedException();
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

        public Task<IReadOnlyList<Product>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> ListAsync(ISpecification<Product> spec)
        {
            throw new NotImplementedException();
        }

        public Task ListAsync()
        {
            throw new NotImplementedException();
        }

        public IResult update(Product Entity)
        {
            throw new NotImplementedException();
        }
    }
}
