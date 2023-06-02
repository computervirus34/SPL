using SPL.Models;

namespace SPL.IRepositories
{
    public interface IProspectRepository : IGenericRepository<Prospect>
    {
        Task<string> CreateProspect(Prospect prospect, string crmBaseURL);
    }
}
