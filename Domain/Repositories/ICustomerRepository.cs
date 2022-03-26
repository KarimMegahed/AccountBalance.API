using AccountBalance.API.Domain.Models;

namespace AccountBalance.API.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task<Customer>  GetCustomerDetails(int cutomerID);

    }
}