using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelDb.Models;

namespace ModelDb.Repository
{
    public class ServiceTypeRepository : IRepository<ServiceType>
    {
        public bool AddIfNotExist(ServiceType model)
        {
            using (var db = new Context())
            {
                var serviceType = db.ServiceType.
                             FirstOrDefault(s => s.Name == model.Name);

                if (serviceType != null)
                    return false;

                db.ServiceType.Add(model);
                db.SaveChanges();
                return true;
            }
        }

        public List<ServiceType> GetAll()
        {
            using (var db = new Context())
            {
                return db.ServiceType.ToList();
            }
        }

        public bool Update(ServiceType model)
        {
            throw new NotSupportedException(nameof(ServiceType));
        }
    }
}
