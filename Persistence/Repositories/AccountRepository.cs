using Microsoft.EntityFrameworkCore;
using AccountBalance.API.Domain.Models;
using AccountBalance.API.Domain.Repositories;
using AccountBalance.API.Persistence.Contexts;

namespace AccountBalance.API.Persistence.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        { }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task CreateAccount(Account newAccount)
        {
            await _context.Accounts.AddAsync(newAccount);
        }
    }
}