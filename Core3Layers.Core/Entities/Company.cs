using System;
using System.Collections.Generic;

namespace Core3LayersAPI.Core.Entities
{
    public partial class Company
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
