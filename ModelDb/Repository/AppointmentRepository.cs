using ModelDb.Models;
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
                var appointment =  db.Appointment.
                                     FirstOrDefault(a => a.StartTime == model.StartTime);

                if (appointment != null)
                    return false;

                db.Appointment.Add(model);
                db.SaveChanges();
                return true;
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
            throw new NotImplementedException("I do not need this method for my task");
        }
    }
}
