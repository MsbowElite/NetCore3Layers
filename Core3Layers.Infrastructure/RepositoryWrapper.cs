using Core3Layers.Core.Interfaces;
using Core3Layers.Infrastructure.Repositories;

namespace Core3Layers.Infrastructure
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private ICustomerRepository _customerRepository;
        private ICompanyRepository _companyRepository;
        private IPersonRepository _personRepository;
        private ICustomerPhonesRepository _customerPhonesRepository;

        public RepositoryWrapper(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public ICustomerRepository Customer => _customerRepository ?? (_customerRepository = new CustomerRepository(_applicationDbContext));
        public ICompanyRepository Company => _companyRepository ?? (_companyRepository = new CompanyRepository(_applicationDbContext));
        public IPersonRepository Person => _personRepository ?? (_personRepository = new PersonRepository(_applicationDbContext));
        public ICustomerPhonesRepository CustomerPhones => _customerPhonesRepository ?? (_customerPhonesRepository = new CustomerPhonesRepository(_applicationDbContext));
    }
}
