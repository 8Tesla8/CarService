using System;
using System.Collections.Generic;
using System.Text;

namespace ModelDb.Repository
{
    //almost implement CRUD model
    public interface IRepository<T> { 
        T GetAll(); 
        bool AddIfNotExist(T model);
        bool Update(T model);
    }
}
