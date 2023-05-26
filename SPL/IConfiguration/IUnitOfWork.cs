using SPL.IRepositories;

namespace SPL.IConfiguration
{
    public interface IUnitOfWork
    {
        public IBranchRepository Branch { get; }
        public IProspectRepository Prospect { get; }
        public IContactRepository Contact { get; }
        public IShipmentRepository Shipment { get; }
        public IUserAuthRepository UserAuth { get; }
        public IUPDSGenericResultRepository UPDSGenericResult { get; }
        public IWaselAddressDetailsRepository WaselAddressDetails { get; }
        public IAccountRepository Account { get; }
        Task CompleteAsync();
    }
}
