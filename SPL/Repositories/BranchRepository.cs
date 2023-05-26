using SPL.Data;
using SPL.IRepositories;
using SPL.Models;

namespace SPL.Repositories
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {

        public BranchRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public Task<bool> Add(Branch entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Branch entity)
        {
            throw new NotImplementedException();
        }
    }
}
