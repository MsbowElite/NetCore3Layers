using AutoMapper;
using Core3Layers.Core.Entities;
using Core3Layers.Core.Interfaces;
using Core3Layers.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core3Layers.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryWrapper _rw;
        private readonly IMapper _mapper;

        public CustomerService(IRepositoryWrapper rw, IMapper mapper)
        {
            _rw = rw;
            _mapper = mapper;
        }

        public async Task<Guid?> CreateCustomerAsync(CustomerDTO customerDTO)
        {
            try
            {
                var customer = _mapper.Map<CustomerDTO, Customer>(customerDTO);
                await _rw.Customer.CreateCustomerAsync(customer);

                var company = _mapper.Map<CustomerCompanyDTO, Company>(customerDTO.Company);
                if(company != null)
                {
                    await AddCompanyAsync(company, customer.Id);
                }

                var person = _mapper.Map<CustomerPersonDTO, Person>(customerDTO.Person);
                if (person != null)
                {
                    await AddPersonAsync(person, customer.Id);
                }

                var phones = _mapper.Map<List<CustomerPhoneDTO>, List<CustomerPhones>>(customerDTO.Phones);
                if (phones != null)
                {
                    foreach(var phone in phones)
                    {
                        await AddCustomerPhoneAsync(phone, customer.Id);
                    }
                }

                return customer.Id;
            }catch(Exception ex)
            {
                return null;
            }            
        }

        private async Task AddCompanyAsync(Company company, Guid customerId)
        {
            company.CustomerId = customerId;
            await _rw.Company.CreateCompanyAsync(company);
        }

        private async Task AddPersonAsync(Person person, Guid customerId)
        {
            person.CustomerId = customerId;
            await _rw.Person.CreatePersonAsync(person);
        }

        private async Task AddCustomerPhoneAsync(CustomerPhones customerPhone, Guid customerId)
        {
            customerPhone.CustomerId = customerId;
            await _rw.CustomerPhones.CreateCustomerPhoneAsync(customerPhone);
        }
    }
}
