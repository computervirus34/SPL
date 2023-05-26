using SPL.Data;
using SPL.IRepositories;
using SPL.Models;

namespace SPL.Repositories
{
    public class ShipmentRepository : GenericRepository<Shipment>, IShipmentRepository
    {

        public ShipmentRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public Task<bool> Add(Shipment entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Shipment entity)
        {
            throw new NotImplementedException();
        }
    }
}
