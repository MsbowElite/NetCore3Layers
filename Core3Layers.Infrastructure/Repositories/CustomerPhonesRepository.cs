using Core3Layers.Core.Entities;
using Core3Layers.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core3Layers.Infrastructure.Repositories
{
    public class CustomerPhonesRepository : RepositoryBase<CustomerPhones>, ICustomerPhonesRepository
    {
        public CustomerPhonesRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task CreateCustomerPhoneAsync(CustomerPhones customerPhone)
        {
            Create(customerPhone);
            await SaveAsync();
        }
    }
}
