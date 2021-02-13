using API.Core.Interfaces;
using API.Core.Utilities.Security.Jwt;
using API.Infrastructure.Business.Abstract;
using API.Infrastructure.Business.Concrete;
using API.Infrastructure.Data;
using API.Infrastructure.Implements;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.DependencyResolvers.Autofac
{
   public class AutofacDependencyModules:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EFUserDal>().As<IUserRepository>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerDependency();

        }
    }
}
