using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);

        User GetByMail(string email);
    }
}
