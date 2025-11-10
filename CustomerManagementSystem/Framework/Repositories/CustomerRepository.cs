

using CMS.Entity;
using CMS.Framework.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace CMS.Framework.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly CustomerDBEntities _dbContext;
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = (_dbContext ?? (CustomerDBEntities)dbContext);
        }
    }
}
