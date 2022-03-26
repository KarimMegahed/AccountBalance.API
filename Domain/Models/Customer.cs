
namespace AccountBalance.API.Domain.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}