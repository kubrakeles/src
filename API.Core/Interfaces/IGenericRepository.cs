using API.Core.DbModels;
using API.Core.Entities;
using API.Core.Specifications;
using API.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IGenericRepository<T> where T:class, IEntity, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task ListAsync();
        IResult update(T Entity);
        IResult delete(T  Entity);
        IResult add(T Entity);
       


        //Task<T> Add(T Entity);
    }
}
