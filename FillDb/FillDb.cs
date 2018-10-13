using System;
using ModelDb;
using ModelDb.Models;
using ModelDb.Repository;

namespace FillDb
{
    public class FillDb
    {

        public void Fill()
        {
            FillServiceType();
            FillCarModel();
            FillRepairType();
            FillCar();
            FillUser();
        }

        private void FillServiceType()
        {
            var repository = new ServiceTypeRepository();

            repository.AddIfNotExist(new ServiceType() { Name = "Transmission" });
            repository.AddIfNotExist(new ServiceType() { Name = "Vehicle Maintance" });
            repository.AddIfNotExist(new ServiceType() { Name = "Vehicle Repair" });
            repository.AddIfNotExist(new ServiceType() { Name = "Other" });
        }

        private void FillCarModel()
        {
            var repository = new CarModelRepository();

            repository.AddIfNotExist(new CarModel() { Name = "Opel" });
            repository.AddIfNotExist(new CarModel() { Name = "Nissan" });
            repository.AddIfNotExist(new CarModel() { Name = "Ford" });
            repository.AddIfNotExist(new CarModel() { Name = "KIA" });
        }

        private void FillRepairType()
        {
            var repository = new ServiceTypeRepository();

            var repairType = repository.Find(new ServiceType() { Name = "Vehicle Repair" });
            var otherType = repository.Find(new ServiceType() { Name = "Other" });

            using (var db = new Context())
            {
                db.RepairType.Add(new RepairType()
                {
                    Name = "Check engine",
                    ServiceType = repairType,
                    Price = 220,
                    Hours = 0.4,
                });

                db.RepairType.Add(new RepairType()
                {
                    Name = "Car wash",
                    ServiceType = otherType,
                    Price = 280,
                    Hours = 0.6,
                });

                db.SaveChanges();
            }
        }

        private void FillCar()
        {
            var carModelrepository = new CarModelRepository();

            var ford = carModelrepository.Find(new CarModel() { Name = "Ford" });
            var kia = carModelrepository.Find(new CarModel() { Name = "KIA" });

            var carRepository = new CarRepository();
          
            carRepository.AddIfNotExist(new Car()
            {
                Year = 2002,
                CarModel = ford,
            });
            carRepository.AddIfNotExist(new Car()
            {
                Year = 2008,
                CarModel = kia,
            });
        }

        private void FillUser(){
            var userRepository = new UserRepository();

            userRepository.AddIfNotExist(new User() {
                Email = "newMail@.com"
            });
        }
    }
}
