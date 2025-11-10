
using Framework.Infrustructure;
using LMS.Framework.Repositories;
using LMS.Framework.Repositories.Interfaces;
using System.Data.Entity; 
using System.Threading.Tasks;

namespace Framework.UnitOfWork
{
    public class UnitOfWork<TContext> : Disposable, IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        private DbContext _dbContext;
         
        private IBookRepository _bookRepository;       


        public UnitOfWork()
        {
            _dbContext = new TContext();
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }

        public virtual int Save()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
          return await _dbContext.SaveChangesAsync();
        }

        //instantiate repositories
        public IBookRepository BookRepository => _bookRepository ?? (_bookRepository = new BookRepository(_dbContext));
        

    }
}
