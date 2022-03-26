namespace AccountBalance.API.Dtos
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int AccountId { get; set; }
    }
}
