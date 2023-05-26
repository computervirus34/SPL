using SPL.Data;
using SPL.IRepositories;
using SPL.Models;

namespace SPL.Repositories
{
    public class WaselAddressDetailsRepository : GenericRepository<WaselAddressDetails>, IWaselAddressDetailsRepository
    {

        public WaselAddressDetailsRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public Task<bool> Add(WaselAddressDetails entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(WaselAddressDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
