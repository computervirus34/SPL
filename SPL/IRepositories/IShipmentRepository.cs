using SPL.Models;

namespace SPL.IRepositories
{
    public interface IShipmentRepository : IGenericRepository<Shipment>
    {
        public Task<string> CreateShipment(Shipment shipment, string crmBaseURL); 
    }
}
