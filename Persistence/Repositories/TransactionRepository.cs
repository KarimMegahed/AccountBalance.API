using Microsoft.EntityFrameworkCore;
using AccountBalance.API.Domain.Models;
using AccountBalance.API.Domain.Repositories;
using AccountBalance.API.Persistence.Contexts;

namespace AccountBalance.API.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context)
        { }

        public async Task<IEnumerable<Transaction>> ListAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }
    }
}