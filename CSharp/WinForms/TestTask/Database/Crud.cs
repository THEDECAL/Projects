using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Helpers;

namespace TestTask.Database
{
    class Crud<T> : IDisposable where T : Entity
    {
        readonly TestTaskDbContext _dbCtx;
        readonly DbSet<T> _dbSet;

        public Crud()
        {
            _dbCtx = new TestTaskDbContext();
            _dbSet = _dbCtx.Set<T>();
        }
        public List<T> GetAll() => _dbSet.ToList();
        public T Get(int id) => _dbSet.FirstOrDefault(obj => obj.Id.Equals(id));
        public T Create(T obj)
        {
            obj.DateOfCreation = DateTime.Now;
            return _dbSet.Add(obj);
        }
        public void Update(T obj)
        {
            if (obj != null && obj.Id != 0)
            {
                var oldItem = Get(obj.Id);
                if (oldItem != null)
                {
                    _dbCtx.Entry(oldItem).CurrentValues.SetValues(obj);
                    //obj.Clone(oldItem, "Id");
                    return;
                }
            }
            throw new NullReferenceException();
        }
        public void Delete(T obj)
        {
            if (obj != null)
            {
                _dbSet.Attach(obj);
                _dbSet.Remove(obj);
            }
        }
        public List<T> Find(Func<T, bool> predicat) => _dbSet.Where(predicat).ToList();
        public DbSet<T> GetDbSet() => _dbSet;
        public TestTaskDbContext GetDbCtx() => _dbCtx;
        public void Dispose()
        {
            _dbCtx.SaveChanges();
            _dbCtx.Dispose();
        }
    }
}
