using BL.Managers.Interfaces;
using Data.Repositories.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Utils;
using Data.Repositories;

namespace BL.Managers
{
    public class AuthManager : IAuthManager
    {
        
        public User FindUser(string userName, string password)
        {
            IAuthRepository authRepo = new AuthRepository();
            return authRepo.FindUser(userName, HashHelper.GetMD5HashData(password));
        }
    }
}
