using Core3Layers.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core3LayersAPI.Core.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
    }
}
