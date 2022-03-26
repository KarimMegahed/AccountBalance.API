namespace AccountBalance.API.Dtos
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public IList<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();
        public int CustomerId { get; set; }
    }
}