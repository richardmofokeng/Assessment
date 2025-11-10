using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CMS.Framework
{
  public interface IGenericRepository<T>
  {
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> expression);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
