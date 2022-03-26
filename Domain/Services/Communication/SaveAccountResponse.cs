using AccountBalance.API.Dtos;

namespace AccountBalance.API.Domain.Services.Communication
{
    public class SaveAccountResponse : BaseResponse
    {
        public AccountDto Account { get; private set; }

        private SaveAccountResponse(bool success, string message, AccountDto account) : base(success, message)
        {
            Account = account;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="account">Saved account.</param>
        /// <returns>Response.</returns>
        public SaveAccountResponse(AccountDto account) : this(true, string.Empty, account)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveAccountResponse(string message) : this(false, message, null)
        { }
    }
}