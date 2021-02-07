using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace API.Core.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(Expression<Func<User, bool>> filter);
    }
}
