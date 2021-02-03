﻿using API.Core.DbModels;
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
            AddInclude(x => x.ProductBrand);
            AddInclude(y => y.ProductType);
        }

    }
}
