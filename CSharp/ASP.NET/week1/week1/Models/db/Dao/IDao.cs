using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace week1.Models.db
{
    public interface IDao<T>
    {
        T Get(int id);
        List<T> GetAll(Func<T, bool> predicate = null);
        bool Save(T item);
        bool Delete(int id);
        bool Update(T item);
    }
}