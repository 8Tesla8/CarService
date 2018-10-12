using System;
using ModelDb.Repository;

namespace ModelDb.Factory
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public AppointmentRepository GetAppointmentRepository()
        {
            return new AppointmentRepository();
        }

        public CarModelRepository GetModelRepository()
        {
            return new CarModelRepository();
        }

        public CarRepository GetCarRepository()
        {
            return new CarRepository();
        }

        public ServiceTypeRepository GetServiceType()
        {
            return new ServiceTypeRepository();
        }

        public UserRepository GetUserRepository(){
            return new UserRepository();
        }
    }
}
