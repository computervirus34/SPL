using SPL.Models;

namespace SPL.IRepositories
{
    public interface IPinCodeRepository : IGenericRepository<PinCodeModel>
    {
        Task<PinCodeModel> GetPinCode(PinCodeModel pinCode, string externalBaseURL);
    }
}
