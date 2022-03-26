using Microsoft.AspNetCore.Mvc;
using AccountBalance.API.Services;
using AccountBalance.API.Dtos;


namespace AccountBalance.API.Controllers
{
   public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("Accounts/GetAllAccounts")]
        public async Task<IEnumerable<AccountDto>> GetAllAsync()
        {
            var accounts = await _accountService.ListAsync();
            return accounts;
        }
        [HttpPost]
        [Route("Accounts/CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody] SaveAccountDto account)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _accountService.CreateAccount(account);

            if (!result.Success)
                return BadRequest(result.Message);

            var accountResource = result.Account;
            return Ok(accountResource);
        }
    }
}
