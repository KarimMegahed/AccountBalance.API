namespace AccountBalance.API.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}