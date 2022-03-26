namespace AccountBalance.API.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public IList<AccountDto> Accounts { get; set; } = new List<AccountDto>();
    }
}
