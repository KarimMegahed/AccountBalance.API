using AccountBalance.API.Domain.Models;

namespace AccountBalance.API.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> ListAsync();
        Task CreateAccount(Account newAccount);
    }
}