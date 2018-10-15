using System;
using Autofac;
using CarServiceServer.Factory;
using ModelDb.Factory;
using ModelDb.Repository;

namespace CarServiceServer.Controllers
{
    static partial class Injection
    {
        private static void CreateClassMap(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>();

            builder.RegisterType<AppointmentRepository>().As<AppointmentRepository>();
            builder.RegisterType<CarModelRepository>().As<CarModelRepository>();
            builder.RegisterType<CarRepository>().As<CarRepository>();
            builder.RegisterType<ServiceTypeRepository>().As<ServiceTypeRepository>();
            builder.RegisterType<UserRepository>().As<UserRepository>();
        }
    }
}
