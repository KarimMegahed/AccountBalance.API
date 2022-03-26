using AccountBalance.API.Domain.Models;
using AccountBalance.API.Domain.Repositories;
using AccountBalance.API.Dtos;
using AutoMapper;

namespace AccountBalance.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All Customers Stored
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CustomerDto>> ListAsync()
        {
            IEnumerable<Customer> result = await _customerRepository.ListAsync();
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(result);
                
        }
        /// <summary>
        /// Get Customer Details  (Personal, Accounts and Transactions) by ID
        /// </summary>
        /// <param name="cutomerID"></param>
        /// <returns></returns>
        public async Task<CustomerDto> GetCustomerDetails(int cutomerID)
        {
            Customer result =  await _customerRepository.GetCustomerDetails(cutomerID);
            return _mapper.Map<Customer, CustomerDto>(result);
        }

    }
}
