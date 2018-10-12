using System;
using ModelDb.Repository;

namespace ModelDb.Factory
{
    public interface IRepositoryFactory
    {
        AppointmentRepository GetAppointmentRepository();
        CarModelRepository GetModelRepository();
        CarRepository GetCarRepository();
        ServiceTypeRepository GetServiceType();
        UserRepository GetUserRepository();
    }
}
