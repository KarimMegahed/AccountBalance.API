namespace AccountBalance.API.Domain.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}