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

namespace API.Infrastructure.Data
{
    public class EFUserDal : IUserRepository
    {
        public User GetByMail(Expression<Func<User, bool>> filter)
        {
            using (var context = new DemiralpContext())
            {
                return context.Set<User>().SingleOrDefault(filter);
            }
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using(var context=new DemiralpContext())
            {
                var result = from OperationClaim in context.OperationClaims
                             join UserOperationClaim in context.UserOperationClaims
                             on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                             where UserOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = OperationClaim.Id, Name = OperationClaim.Name };
                return result.ToList();
            }
        }

        public Task<User> GetEntityWithSpec(ISpecification<User> spec)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<User>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<User>> ListAsync(ISpecification<User> spec)
        {
            throw new NotImplementedException();
        }

        public Task ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
