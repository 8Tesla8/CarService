﻿using System;
using System.Collections.Generic;
using System.Linq;
using ModelDb.Models;

namespace ModelDb.Repository
{
    public class CarModelRepository : IRepository<CarModel>
    {
        public bool AddIfNotExist(CarModel model)
        {
            using (var db = new Context())
            {
                var carModel = db.CarModel.
                                 FirstOrDefault(c => c.Name == model.Name);

                if (carModel != null)
                    return false;

                db.CarModel.Add(model);
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// <c>Get full model</c>  
        /// </summary>
        public CarModel Find(CarModel model)
        {
            using (var db = new Context())
            {
                return db.CarModel.
                            FirstOrDefault(c => c.Name == model.Name);
            }
        }

        public List<CarModel> GetAll()
        {
            using (var db = new Context())
            {
                return db.CarModel.ToList();
            }
        }

        public bool Update(CarModel model)
        {
            using (var db = new Context())
            {
                var carModel = db.CarModel.
                                 FirstOrDefault(c => c.Id == model.Id);

                if (carModel == null)
                    return false;

                carModel.Name = model.Name;

                db.SaveChanges();
                return true;
            }
        }
    }
}
