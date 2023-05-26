using SPL.Data;
using SPL.IRepositories;
using SPL.Models;

namespace SPL.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {

        public ContactRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public Task<bool> Add(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
