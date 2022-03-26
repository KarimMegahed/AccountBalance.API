using System.ComponentModel.DataAnnotations;

namespace AccountBalance.API.Dtos
{
    public class SaveAccountDto
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public decimal Balance { get; set; }
    }
}