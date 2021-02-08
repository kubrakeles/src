using API.Core.DbModels;
using API.Core.Dtos;
using API.Core.Utilities.Messages;
using API.Core.Utilities.Result;
using API.Core.Utilities.Security.Encryption.Hashing;
using API.Core.Utilities.Security.Jwt;
using API.Infrastructure.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.Business.Concrete
{
    public class AuthManager : IAuthService
    {
      IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        { var claims=_userService.GetClaims(user);
            //front endde kayıt olan kullanıcı kayıt olduktan  veya giriş yaptıktan sonra bir token alacak bunla işlemler gerçekleştirecek
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if(userToCheck==null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            //Kullanıcıyı bulduk şimdi kullanıcının gönderdiği şifreyi kontrol edicez.
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            //buraya gelirse veriler doğru demek 
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

      

        public IResult UserExists(string email)//Kullanıcı var mı kontrolü için
        {
            if(_userService.GetByMail(email)!=null)
            {//kullanıcı kayıt olmaya çalıştığında böyle bir e-mail varsa böyle bir hata döndürüyoruz.
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
