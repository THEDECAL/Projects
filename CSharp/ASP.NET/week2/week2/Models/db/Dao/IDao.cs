using System;
using System.Collections.Generic;

namespace week2.Models.db
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