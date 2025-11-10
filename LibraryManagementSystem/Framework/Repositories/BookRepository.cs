
using Entity;
using LMS.Framework.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace LMS.Framework.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly LibraryDBEntities _dbContext;
        public BookRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = (_dbContext ?? (LibraryDBEntities)dbContext);
        }
    }
}
