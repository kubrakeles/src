using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Specifications
{
    public class ProductsWithImage : BaseSpecification<Product>
    {
        public ProductsWithImage()
        {
            AddInclude(y => y.Images);
        }

        public ProductsWithImage(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Images);
        }
    }
}
