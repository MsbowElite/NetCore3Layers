using Core3Layers.Core.Interfaces;
using Core3Layers.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core3Layers.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<(List<Customer>, int Count)> GetAllCustomersAsync(int pageSize, int pageIndex)
        {
            var listAll = await ListAllAsync(pageSize, pageIndex);
            return (await listAll.Item1.Include(i => i.Company)
                                       .Include(i => i.Person)
                                       .Include(i => i.CustomerPhones).ToListAsync(),
                                                                      listAll.Count);
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid customerId)
        {
            return await FindByConditionAsync(c => c.Id == customerId);
        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public async Task DeleteCustomerAsync(Guid customerId)
        {
            Delete(await FindByConditionAsync(f => f.Id == customerId));
            await SaveAsync();
        }
    }
}
