﻿using ModelDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelDb.Repository
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        public bool AddIfNotExist(Appointment model)
        {
            using (var db = new Context())
            {
                var appointment = db.Appointment.
                                     FirstOrDefault(a => a.StartTime == model.StartTime);

                if (appointment != null)
                    return false;

                if (model.Car != null)
                    model.Car = db.Car.
                        FirstOrDefault(c => c.Id == model.CarId);

                if (model.ServiceType != null)
                    model.ServiceType = db.ServiceType.
                        FirstOrDefault(s => s.Id == model.ServiceTypeId);

                model.User = db.User.
                    FirstOrDefault(u=> u.Id == model.UserId);

                db.Appointment.Add(model);
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// <c>Get full model</c>  
        /// </summary>
        public Appointment Find(Appointment model)
        {
            using (var db = new Context())
            {
                return db.Appointment.
                     FirstOrDefault(a => a.StartTime == model.StartTime);
            }
        }

        public List<Appointment> GetAll()
        {
            using (var db = new Context())
            {
                return db.Appointment.ToList();
            }
        }

        public bool Update(Appointment model)
        {
            using (var db = new Context())
            {
                var appointment = db.Appointment.
                     FirstOrDefault(a => a.StartTime == model.StartTime);

                if (appointment == null)
                    return false;

                appointment = model;

                db.SaveChanges();
                return true;
            }
        }
    }
}
