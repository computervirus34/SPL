using SPL.Models;

namespace SPL.IRepositories
{
    public interface IUserAuthRepository : IGenericRepository<UserAuth>
    {
        Task<string> ChangeUserAuth(UserAuth userAuth, string crmBaseURL);
    }
}
