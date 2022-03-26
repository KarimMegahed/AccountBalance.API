using AccountBalance.API.Dtos;

namespace AccountBalance.API.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> ListAsync();
        Task<CustomerDto> GetCustomerDetails(int cutomerID);
    }
}