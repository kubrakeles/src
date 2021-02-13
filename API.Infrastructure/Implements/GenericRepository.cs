using API.Core.DbModels;
using API.Core.Entities;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Core.Utilities.Messages;
using API.Core.Utilities.Result;
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

        public IResult add(T entity)
        {
            var context = _demiralpContext;

            var addedEntity = _demiralpContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
            return new SuccessResult(Messages.Added);
        }

        public IResult delete(T entity)
        {
            var context = _demiralpContext;

            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
            return new SuccessResult(Messages.Deleted);
        }


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

        public IResult update(T entity)
        {
            var context = _demiralpContext;
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
            return new SuccessResult(Messages.Updated);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvalutor<T>.GetQuery(_demiralpContext.Set<T>().AsQueryable(), spec);
        }

    }
}
