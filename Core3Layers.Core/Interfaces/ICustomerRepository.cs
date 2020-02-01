using Core3Layers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core3Layers.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<(List<Customer>, int Count)> GetAllCustomersAsync(int pageSize, int pageIndex);
        Task CreateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Guid customerId);
        Task<Customer> GetCustomerByIdAsync(Guid customerId);
    }
}
