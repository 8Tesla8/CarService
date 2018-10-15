using System;
using CarServiceServer.Controllers;
using ModelDb.Factory;
using ModelDb.Repository;

namespace CarServiceServer.Factory
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public AppointmentRepository GetAppointmentRepository()
        {
            return Injection.Resolve<AppointmentRepository>();
        }

        public CarModelRepository GetModelRepository()
        {
            return Injection.Resolve<CarModelRepository>();
        }

        public CarRepository GetCarRepository()
        {
            return Injection.Resolve<CarRepository>();
        }

        public ServiceTypeRepository GetServiceType()
        {
            return Injection.Resolve<ServiceTypeRepository>();
        }

        public UserRepository GetUserRepository()
        {
            return Injection.Resolve<UserRepository>();
        }
    }
}
