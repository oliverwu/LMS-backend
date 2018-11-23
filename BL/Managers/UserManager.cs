using BL.Managers.Interfaces;
using Data.Repositories.Interfaces;
using Model.Dtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Utils;

namespace BL.Managers
{
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepository;

        public object Utilis { get; private set; }

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDisplayDto CreateUser(UserRegisterDto user)
        {
            User newUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = HashHelper.GetMD5HashData(user.Password),
                CreatedOn = DateTime.Now,
            };

            var createdUser = _userRepository.Add(newUser);

            UserDisplayDto displayUser = new UserDisplayDto()
            {
                Id = createdUser.Id,
                UserName = createdUser.UserName,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email,
            };

            return displayUser;
        }

        public User FindUser(string userName, string password)
        {
            var passwordHash = HashHelper.GetMD5HashData(password);
            return _userRepository.FindUser(userName, passwordHash);
        }
    }
}
