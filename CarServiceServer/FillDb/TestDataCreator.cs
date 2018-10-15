using System;
using ModelDb;
using ModelDb.Models;
using ModelDb.Repository;
using System.Linq;

namespace CarServiceServer.FillDb
{
    public class TestDataCreator
    {
        public void Fill()
        {
            var repository = new UserRepository();

            if (repository.GetAll().Count > 0)
                return;

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
            using (var db = new Context())
            {
                var repairType = db.ServiceType.FirstOrDefault(s => s.Name == "Vehicle Repair");
                db.RepairType.Add(new RepairType()
                {
                    Name = "Check engine",
                    ServiceType = repairType,
                    ServiceTypeId = repairType.Id,
                    Price = 220,
                    Hours = 0.4,
                });

                var otherType = db.ServiceType.FirstOrDefault(s => s.Name == "Other");
                db.RepairType.Add(new RepairType()
                {
                    Name = "Car wash",
                    ServiceType = otherType,
                    ServiceTypeId = otherType.Id,
                    Price = 280,
                    Hours = 0.6,
                });

                db.SaveChanges();
            }
        }

        private void FillCar()
        {
            using (var db = new Context())
            {
                var ford = db.CarModel.FirstOrDefault(s => s.Name == "Ford");
                db.Car.Add(new Car()
                {
                    Year = 2002,
                    CarModel = ford,
                });

                var kia = db.CarModel.FirstOrDefault(s => s.Name == "KIA");
                db.Car.Add(new Car()
                {
                    Year = 2008,
                    CarModel = kia,  
                });

                db.SaveChanges();
            }
        }

        private void FillUser()
        {
            var userRepository = new UserRepository();

            userRepository.AddIfNotExist(new User()
            {
                Email = "newMail@.com"
            });
        }
    }
}
