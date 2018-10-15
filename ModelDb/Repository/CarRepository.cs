using ModelDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelDb.Repository
{
    public class CarRepository : IRepository<Car>
    {
        public bool AddIfNotExist(Car model)
        {
            using (var db = new Context())
            {
                var car = db.Car.
                            FirstOrDefault(s => s.Year == model.Year &&
                                                s.CarModel.Name == model.CarModel.Name);

                if (car != null)
                    return false;

                model.Id = db.Car.Count() + 1;

                model.CarModel = db.CarModel.FirstOrDefault(c => c.Id == model.CarModel.Id);

                db.Car.Add(model);
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// <c>Get full model</c>  
        /// </summary>
        public Car Find(Car model)
        {
            using (var db = new Context())
            {
                return db.Car.
                          FirstOrDefault(s => s.Year == model.Year &&
                                              s.CarModel.Name == model.CarModel.Name);
            }
        }

        public List<Car> GetAll()
        {
            using (var db = new Context())
            {
                return db.Car.ToList();
            }
        }

        public bool Update(Car model)
        {
            using (var db = new Context())
            {
                var car = db.Car.
                            FirstOrDefault(s => s.Year == model.Year &&
                                                s.CarModel.Name == model.CarModel.Name);

                if (car == null)
                    return false;

                if (model.CarModel == null)
                    return false;
                    
                car.Year = model.Year;

                if (car.CarModel.Name != model.CarModel.Name)
                {
                    var carModel = db.CarModel.FirstOrDefault(c => c.Name == model.CarModel.Name);

                    if (carModel != null)
                    {
                        car.CarModel = carModel;
                    }
                }

                db.SaveChanges();
                return true;
            }
        }
    }
}
