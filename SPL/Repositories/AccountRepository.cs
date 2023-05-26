using SPL.Data;
using SPL.IRepositories;
using SPL.Models;

namespace SPL.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {

        public AccountRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public Task<bool> Add(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
