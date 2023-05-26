using SPL.Data;
using SPL.IRepositories;
using SPL.Models;

namespace SPL.Repositories
{
    public class ProspectRepository : GenericRepository<Prospect>, IProspectRepository
    {

        public ProspectRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public Task<bool> Add(Prospect entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Prospect entity)
        {
            throw new NotImplementedException();
        }

    }
}
