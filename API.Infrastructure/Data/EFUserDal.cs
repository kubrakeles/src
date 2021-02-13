using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Infrastructure.DataContext;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using API.Infrastructure.Business.Abstract;

namespace API.Infrastructure.Data
{
    public class EFUserDal : IUserRepository
    {
        private readonly DemiralpContext _demiralpContext;
        public EFUserDal(DemiralpContext demiralpContext)
        {
            _demiralpContext = demiralpContext;

        }
        public User GetByMail(Expression<Func<User, bool>> filter)
        {
            var context = _demiralpContext;
            
                return context.Set<User>().SingleOrDefault(filter);
            
        }
        public void Add(User user)
        {
            var context = _demiralpContext;
            
                var addedEntity = _demiralpContext.Entry(user);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using(var context=_demiralpContext)
            {
                var result = from OperationClaim in context.OperationClaims
                             join UserOperationClaim in context.UserOperationClaims
                             on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                             where UserOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = OperationClaim.Id, Name = OperationClaim.Name };
                return result.ToList();
            }
        }

   
    }
}
