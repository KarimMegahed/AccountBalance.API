using Microsoft.EntityFrameworkCore;
using AccountBalance.API.Domain.Models;
using AccountBalance.API.Domain.Repositories;
using AccountBalance.API.Persistence.Contexts;

namespace AccountBalance.API.Persistence.Repositories
{
	public class CustomerRepository : BaseRepository, ICustomerRepository
	{
		public CustomerRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Customer>> ListAsync()
		{
			return await _context.Customers.ToListAsync();
		}

		public async  Task<Customer> GetCustomerDetails(int customerID)
        {
			return await _context.Customers
				.Include(a => a.Accounts)
				.ThenInclude(b => b.Transactions)
				.SingleOrDefaultAsync(a => a.CustomerId == customerID);
		}
	}
}