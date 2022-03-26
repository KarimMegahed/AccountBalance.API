using AccountBalance.API.Domain.Models;
using AccountBalance.API.Domain.Repositories;
using AccountBalance.API.Domain.Services.Communication;
using AccountBalance.API.Dtos;
using AutoMapper;

namespace AccountBalance.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All Accounts Stored
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AccountDto>> ListAsync()
        {
            IEnumerable<Account> result = await _accountRepository.ListAsync();
            return _mapper.Map<IEnumerable<Account>, IEnumerable<AccountDto>>(result);
        }
        /// <summary>
        /// Create New Account for existing Customer
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<SaveAccountResponse> CreateAccount(SaveAccountDto account)
        {
            try
            {
                Account newAccount = _mapper.Map<SaveAccountDto, Account>(account);
                await _accountRepository.CreateAccount(newAccount);
                if (newAccount.Balance > 0)
                {
                    Transaction newTransaction = new Transaction()
                    {
                        TransactionDate = DateTime.Now,
                        Amount = newAccount.Balance,
                        AccountId = newAccount.AccountId
                    };

                    await _transactionRepository.AddAsync(newTransaction);
                }
                await _unitOfWork.CompleteAsync();
                AccountDto responseAccount = _mapper.Map<Account, AccountDto>(newAccount);
                return new SaveAccountResponse(responseAccount);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveAccountResponse($"An error occurred when saving the account: {ex.Message}");
            }
        }
    }
}
