using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QcsWeb.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AppDbContext _appDbContext;
        private DbSet<T> table;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            table = _appDbContext.Set<T>();
        }

        public void Delete(object Id)
        {
            T exists = table.Find(Id);
            table.Remove(exists);
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
