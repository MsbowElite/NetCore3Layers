using AutoMapper;
using Core3Layers.Core.Entities;
using Core3Layers.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Layers.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDTO, Customer>(MemberList.Source);
            CreateMap<Customer, CustomerDTO>(MemberList.Source);
            CreateMap<CustomerCompanyDTO, Company>(MemberList.Source);
            CreateMap<Company, CustomerCompanyDTO>(MemberList.Source);
            CreateMap<CustomerPersonDTO, Person>(MemberList.Source);
            CreateMap<Person, CustomerPersonDTO>(MemberList.Source);
        }
    }
}
