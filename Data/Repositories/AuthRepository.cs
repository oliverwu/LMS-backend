﻿using Data.Database;
using Data.Repositories.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public User FindUser(string userName, string passwordHash)
        {
            using (var context = new LMSDBEntities())

            {
                return context.Users.FirstOrDefault(x => x.UserName == userName && x.PasswordHash == passwordHash);
            }
        }

    }
}
