using Core3Layers.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core3Layers.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<Guid?> CreateCustomerAsync(CustomerDTO customerDTO);
    }
}
