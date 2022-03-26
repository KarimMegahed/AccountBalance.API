using AccountBalance.API.Domain.Services.Communication;
using AccountBalance.API.Dtos;

namespace AccountBalance.API.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> ListAsync();
        Task<SaveAccountResponse> CreateAccount(SaveAccountDto account);
    }
}