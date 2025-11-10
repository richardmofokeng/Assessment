using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Framework
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private DbSet<T> _set;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _set = dbContext.Set<T>();
        }

        public IQueryable<T> Query() => _set;
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression) => _set.Where(expression).ToList();

        public IEnumerable<T> GetAll() => _set.AsEnumerable().ToList();
        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> expression) => _set.Where(expression).AsQueryable();
        public T GetById(int id) => _set.Find(id); 
        public void Add(T entity) => _set.Add(entity);
        public void Update(T entity) => _dbContext.Entry(entity).State = EntityState.Modified;
        public void Delete(T entity) => _set.Remove(entity); 
      
    
    }
}
