using API.Core.DbModels;
using API.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.Business.Abstract
{
    interface IProductService
    {
        IDataResult<List<Product>> getAll();
        IDataResult<List<Product>> getByCategory(int categoryId);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
    }
}
