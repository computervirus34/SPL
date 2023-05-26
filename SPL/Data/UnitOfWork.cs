using SPL.IConfiguration;
using SPL.IRepositories;
using SPL.Repositories;

namespace SPL.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SPLDatabaseContext _context;
        private readonly ILogger _logger;
        public IBranchRepository Branch { get; private set; }
        public IContactRepository Contact { get; set; }
        public IShipmentRepository Shipment { get; private set; }
        public IProspectRepository Prospect { get; set; }
        public IUserAuthRepository UserAuth { get; set; }
        public IUPDSGenericResultRepository UPDSGenericResult { get; set; }
        public IWaselAddressDetailsRepository WaselAddressDetails { get; set; }
        public IAccountRepository Account { get; set; }

        public UnitOfWork(
            SPLDatabaseContext context,
            ILoggerFactory loggerFactory
            )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            Branch = new BranchRepository(_context, _logger);
            Shipment = new ShipmentRepository(_context, _logger);
            Contact = new ContactRepository(_context, _logger);
            Prospect = new ProspectRepository(_context, _logger);
            UserAuth = new UserAuthRepository(_context, _logger);
            UPDSGenericResult = new UPDSGenericResultRepository(_context, _logger);
            WaselAddressDetails = new WaselAddressDetailsRepository(_context, _logger);
            Account = new AccountRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
