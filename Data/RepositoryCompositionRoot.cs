﻿using Autofac;
using Data.Database;
using Data.Repositories;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RepositoryCompositionRoot
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(currentAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            builder.RegisterType<LMSDBEntities>().AsSelf().InstancePerRequest();
           // builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            //builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerRequest();

        }

    }
}
