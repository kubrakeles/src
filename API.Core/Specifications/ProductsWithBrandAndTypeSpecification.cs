using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace API.Core.Specifications
{
 public class ProductsWithBrandAndTypeSpecification:BaseSpecification<Product>
    {
        public ProductsWithBrandAndTypeSpecification()
        {
            AddInclude(y => y.Created);
        }
        public ProductsWithBrandAndTypeSpecification(int id)
            :base(x=>x.Id==id)
        {
            AddInclude(x => x.Created);
        }

        
        



    }
}
