
using LMS.Framework.Repositories.Interfaces;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Framework.UnitOfWork
{
  public interface IUnitOfWork<T> : IDisposable where T : DbContext
  {
        int Save();
        Task<int> SaveChangesAsync();

        //register repositories
        IBookRepository BookRepository { get; }
        
         
  }
}
