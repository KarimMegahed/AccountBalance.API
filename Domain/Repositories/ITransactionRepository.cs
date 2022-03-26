using AccountBalance.API.Domain.Models;

namespace AccountBalance.API.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> ListAsync();
        Task AddAsync(Transaction transaction);
    }
}