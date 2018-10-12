using System;
using ModelDb.DTO;
using ModelDb.Factory;
using ModelDb.Models;

namespace CarServiceServer.Converter
{
    public class AppointmentConverter
    {
        private readonly IRepositoryFactory _repositoryFactory; 

        public AppointmentConverter(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }


        public Appointment Convert(AppointmentDTO dto) 
        {
            var car = GetCar(dto);
            var user = GetUser(dto);
            var serviceType = GetServiceType(dto);

            return new Appointment()
            {
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,

                Message = dto.Message,

                User = user,
                UserId = user.Id,

                Car = car,
                CarId = car.Id,

                ServiceType = serviceType,
                ServiceTypeId = serviceType.Id,
            };
        }


        private ServiceType GetServiceType(AppointmentDTO dto)
        {
            var serviceTypeRepository = _repositoryFactory.GetServiceType();
            var serviceType = serviceTypeRepository.Find(new ServiceType() 
            {
                Name = dto.ServiceType 
            });

            return serviceType;
        }


        private Car GetCar(AppointmentDTO dto)
        {
            var carModelRepository = _repositoryFactory.GetModelRepository();
            var foundCarModel = carModelRepository.Find(new CarModel()
            {
                Name = dto.Car.CarModel
            });


            var carRepository = _repositoryFactory.GetCarRepository();
            var car = new Car()
            {
                ModelId = foundCarModel.Id,
                CarModel = foundCarModel,
                Year = dto.Car.Year,
            };

            var foundCar = carRepository.Find(car);
            if (foundCar == null)
            {
                carRepository.AddIfNotExist(car);
                car = carRepository.Find(car);
            }

            return car;
        }


        private User GetUser(AppointmentDTO dto)
        {
            var userRepository = _repositoryFactory.GetUserRepository();
            var user = new User()
            {
                Notify = dto.User.Notify,

                Email = dto.User.Email,
                PhoneNumber = dto.User.PhoneNumber,

                FirstName = dto.User.FirstName,
                SecondName = dto.User.SecondName
            };

            var foundUser = userRepository.Find(user);
            if (foundUser == null)
            {
                userRepository.AddIfNotExist(user);
                user = userRepository.Find(user);
            }

            return user;
        }
    }
}
