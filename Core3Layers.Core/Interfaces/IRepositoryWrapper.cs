﻿using Core3Layers.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core3Layers.Core.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        ICompanyRepository Company { get; }
        IPersonRepository Person { get; }
        ICustomerPhonesRepository CustomerPhones { get; }
        Task SaveChangesAsync();
    }
}
