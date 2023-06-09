using SPL.Models;

namespace SPL.IRepositories
{
    public interface IUPDSGenericResultRepository:IGenericRepository<WaselAddressDetails>
    {
        Task<GetUPDSAddressesResponse> GetAddresses(PinCodeModel pinCode, string externalBaseURL);
    }
}
