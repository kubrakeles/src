using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaim);//User bilgisine gore token üretecek, 
        //operationclaim üyenin rollerini token a ekletmek istediğiiz için ekliyoruz parametre olrak
    }
}
