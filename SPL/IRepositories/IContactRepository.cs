using SPL.Models;

namespace SPL.IRepositories
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        Task<string> CreateContact(Contact contact, string crmBaseURL);
    }
}
