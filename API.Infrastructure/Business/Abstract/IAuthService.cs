using API.Core.DbModels;
using API.Core.Dtos;
using API.Core.Utilities.Result;
using API.Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);

        IDataResult<User> Login(UserForLoginDto userForLoginDto); //kullanıcı var mı kontorolü

        IResult UserExists(string email);//Kullanıcı daha önce kaydolmuşsa
        IDataResult<AccessToken> CreateAccessToken(User user);


    }
}
