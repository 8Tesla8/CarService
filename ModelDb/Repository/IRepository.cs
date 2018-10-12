using System;
using System.Collections.Generic;
using System.Text;

namespace ModelDb.Repository
{
    //almost CRUD model
    public interface IRepository<T> { 
        List<T> GetAll(); 
        bool AddIfNotExist(T model);
        bool Update(T model);
        T Find(T model);
    }
}
