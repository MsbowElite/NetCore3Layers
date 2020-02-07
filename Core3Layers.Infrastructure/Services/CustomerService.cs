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
                _rw.Customer.CreateCustomer(customer);
                
                await _rw.SaveChangesAsync();

                customerDTO.Id = customer.Id;

                var company = _mapper.Map<CustomerCompanyDTO, Company>(customerDTO.Company);
                if(company != null)
                {
                    company.Customer = customer;
                    AddCompany(company, customer.Id);
                }

                var person = _mapper.Map<CustomerPersonDTO, Person>(customerDTO.Person);
                if (person != null)
                {
                    AddPerson(person, customer.Id);
                }

                var phones = _mapper.Map<List<CustomerPhoneDTO>, List<CustomerPhones>>(customerDTO.Phones);
                if (phones != null)
                {
                    foreach(var phone in phones)
                    {
                        AddCustomerPhone(phone, customer.Id);
                    }
                }

                await _rw.SaveChangesAsync();

                return customer.Id;
            }catch(Exception ex)
            {
                return null;
            }            
        }

        private void AddCompany(Company company, Guid customerId)
        {
            company.CustomerId = customerId;
            _rw.Company.CreateCompany(company);
        }

        private void AddPerson(Person person, Guid customerId)
        {
            person.CustomerId = customerId;
            _rw.Person.CreatePerson(person);
        }

        private void AddCustomerPhone(CustomerPhones customerPhone, Guid customerId)
        {
            customerPhone.CustomerId = customerId;
            _rw.CustomerPhones.CreateCustomerPhone(customerPhone);
        }
    }
}
