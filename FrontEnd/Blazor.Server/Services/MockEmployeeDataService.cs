using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Shared;

namespace Blazor.Server.Services
{
    public class MockCustomerDataService : ICustomerDataService
    {
        public Task<CustomerDTO> AddCustomer(CustomerDTO customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedItemsViewModel<CustomerDTO>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO> GetCustomerDetails(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
