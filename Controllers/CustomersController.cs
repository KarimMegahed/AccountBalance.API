using Microsoft.AspNetCore.Mvc;
using AccountBalance.API.Services;
using AccountBalance.API.Dtos;

namespace AccountBalance.API.Controllers
{
    [Route("/api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService accountService)
        {
            _customerService = accountService;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _customerService.ListAsync();
            return customers;
        }
        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerDetails(int customerId)
        {
            try
            {
                var customer = await _customerService.GetCustomerDetails(customerId);
                if (customer != null)
                {
                    return Ok(customer);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}