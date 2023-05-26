using SPL.Data;
using SPL.IRepositories;
using SPL.Models;

namespace SPL.Repositories
{
    public class UserAuthRepository : GenericRepository<UserAuth>, IUserAuthRepository
    {

        public UserAuthRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public Task<bool> Add(UserAuth entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UserAuth entity)
        {
            throw new NotImplementedException();
        }

    }
}