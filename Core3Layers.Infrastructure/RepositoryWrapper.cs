using Core3Layers.Core.Interfaces;
using Core3Layers.Core.Interfaces;
using Core3Layers.Infrastructure.Repositories;

namespace Core3Layers.Infrastructure
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private ICustomerRepository _customerRepository;

        public RepositoryWrapper(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public ICustomerRepository Customer => _customerRepository ?? (_customerRepository = new CustomerRepository(_applicationDbContext));
    }
}
