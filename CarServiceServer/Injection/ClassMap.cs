using System;
using Autofac;
using ModelDb.Factory;

namespace CarServiceServer.Controllers
{
    static partial class Injection
    {
        private static void CreateClassMap(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>();
        }
    }
}
