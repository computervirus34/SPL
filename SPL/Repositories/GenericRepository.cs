using Microsoft.EntityFrameworkCore;
using SPL.Data;
using SPL.IRepositories;

namespace SPL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected SPLDatabaseContext _context;
        protected DbSet<T> _dbSet;
        protected readonly ILogger _logger;
        public GenericRepository(
            SPLDatabaseContext context,
            ILogger logger
            )
        {
            _context = context;
            _logger = logger;
            this._dbSet = context.Set<T>();
        }
        public Task<bool> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByID(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
