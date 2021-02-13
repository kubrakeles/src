using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
             _userRepository.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userRepository.GetByMail(filter:u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaims(user);
        }
    }
}
