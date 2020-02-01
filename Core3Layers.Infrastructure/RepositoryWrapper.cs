using Core3Layers.Core.Interfaces;
using Core3LayersAPI.Core.Interfaces;
using Core3LayersAPI.Infrastructure.Repositories;

namespace Core3LayersAPI.Infrastructure
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
