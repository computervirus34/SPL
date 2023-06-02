using SPL.Models;

namespace SPL.IRepositories
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<string> CreateBranch(Branch branch, string crmBaseURL);
    }
}
