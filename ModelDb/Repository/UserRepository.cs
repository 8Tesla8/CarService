using ModelDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelDb.Repository
{
    public class UserRepository : IRepository<User>
    {
        public bool AddIfNotExist(User model)
        {
            using (var db = new Context())
            {
                var user = db.User.
                             FirstOrDefault(u => u.Email == model.Email);

                if (user != null)
                    return false;

                db.User.Add(model);
                db.SaveChanges();
                return true;
            }
        }

        public List<User> GetAll()
        {
            using (var db = new Context())
            {
                return db.User.ToList();
            }
        }

        /// <summary>
        /// <c>Get full model</c>  
        /// </summary>
        public User Find(User model)
        {
            using (var db = new Context())
            {
                return db.User.
                          FirstOrDefault(u => u.Email == model.Email);
            }
        }

        /// <summary>
        /// <c>Update only notify property</c>  
        /// </summary>
        public bool Update(User model)
        {
            using (var db = new Context())
            {
                var user = db.User.
                             FirstOrDefault(u => u.Email == model.Email);

                if (user == null){
                    db.User.Add(model);
                    db.SaveChanges();
                    return true;
                }

                user.Notify = model.Notify;
                db.SaveChanges();
                return true;
            }
        }
    }
}
