using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Shared;

namespace Blazor.Server.Services
{
    public interface ICustomerDataService
    {
        Task<PaginatedItemsViewModel<CustomerDTO>> GetAllCustomers();
        Task<CustomerDTO> GetCustomerDetails(Guid customerId);
        Task<Guid> AddCustomer(CustomerDTO customer);
        Task DeleteCustomer(Guid customerId);
    }
}
