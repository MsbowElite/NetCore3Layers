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

                var person = _mapper.Map<CustomerPersonDTO, Person>(customerDTO.Person);




                return Guid.NewGuid();
            }catch(Exception ex)
            {
                return null;
            }            
        }
    }
}
