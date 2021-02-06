using API.Core.DbModels;
using API.Core.Entities;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Infrastructure.Data;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Implements
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class, IEntity, new()
    {
        private readonly DemiralpContext _demiralpContext;
        public GenericRepository(DemiralpContext demiralpContext)
        {
            _demiralpContext = demiralpContext;
        }

        //public Task<T> Add(T Entity)
        //{
        //    using (var context = new DemiralpContext())
        //    {
        //        int a;
        //        var addedEntity = context.Entry(Entity);
        //        addedEntity.State = EntityState.Added;
        //        a = context.SaveChanges();
        //    }

        //}

        public async Task<T> GetByIdAsync(int id)
        {
            return await _demiralpContext.Set<T>()
                .FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _demiralpContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public Task ListAsync()
        {
            throw new NotImplementedException();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvalutor<T>.GetQuery(_demiralpContext.Set<T>().AsQueryable(), spec);
        }

    }
}
