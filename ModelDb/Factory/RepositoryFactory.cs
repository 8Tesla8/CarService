using System;
using ModelDb.Repository;

namespace ModelDb.Factory
{
    public class RepositoryFactory
    {
        AppointmentRepository GetAppointmentRepository()
        {
            return new AppointmentRepository();
        }

        CarModelRepository GetModelRepository()
        {
            return new CarModelRepository();
        }

        CarRepository GetCarRepository()
        {
            return new CarRepository();
        }

        ServiceTypeRepository GetServiceType()
        {
            return new ServiceTypeRepository();
        }

        UserRepository GetUserRepository(){
            return new UserRepository();
        }
    }
}
