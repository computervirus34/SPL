using SPL.Data;
using SPL.IRepositories;
using SPL.Models;

namespace SPL.Repositories
{
    public class UPDSGenericResultRepository : GenericRepository<UPDSGenericReult>, IUPDSGenericResultRepository
    {

        public UPDSGenericResultRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public Task<bool> Add(UPDSGenericReult entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UPDSGenericReult entity)
        {
            throw new NotImplementedException();
        }
    }
}
