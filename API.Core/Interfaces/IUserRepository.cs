using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace API.Core.Interfaces
{
    public interface IUserRepository
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(Expression<Func<User, bool>> filter);
    }
}
