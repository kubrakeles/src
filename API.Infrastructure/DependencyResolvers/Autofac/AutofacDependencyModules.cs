using API.Core.Interfaces;
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
            //builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerDependency();
        }
    }
}
