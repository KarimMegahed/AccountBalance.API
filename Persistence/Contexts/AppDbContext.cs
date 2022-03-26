using Microsoft.EntityFrameworkCore;
using AccountBalance.API.Domain.Models;

namespace AccountBalance.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>().HasData
            (
                new Customer { CustomerId = 1000, Name = "Karim" , SurName = "Samir" }, // Id set manually due to in-memory provider
                new Customer { CustomerId = 1001, Name = "Carlo", SurName = "Vanhoutte" }
            );
            builder.Entity<Account>().HasData
            (
                new Account { CustomerId = 1000, Balance = 120 ,AccountId = 100001 }, // Id set manually due to in-memory provider
                new Account { CustomerId = 1001, Balance = 100 ,AccountId = 100002 },
                new Account { CustomerId = 1000, Balance = 500 ,AccountId = 100003 }, 
                new Account { CustomerId = 1001, Balance = 720 ,AccountId = 100004 }

            );
            builder.Entity<Transaction>().HasData
            (
                new Transaction { AccountId = 100001, Amount = 200, Id = 1, TransactionDate = DateTime.Now.AddDays(-1) },
                new Transaction { AccountId = 100001, Amount = -80, Id = 2, TransactionDate = DateTime.Now }
                );
        }
    }
}