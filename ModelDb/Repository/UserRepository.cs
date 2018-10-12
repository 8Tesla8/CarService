using ModelDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelDb.Repository
{
    public class UserRepository : IRepository<User>
    {
        public User GetAll()
        {
            throw new NotImplementedException();
        }

        public bool AddIfNotExist(User model)
        {
            throw new NotImplementedException();
        }

        public bool Update(User model)
        {
            //find user if not exist add him

            throw new NotImplementedException();
        }

        public bool AddUser(User user) {

            return true;
        }
    }
}
