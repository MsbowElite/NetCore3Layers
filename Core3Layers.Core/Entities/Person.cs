using System;
using System.Collections.Generic;

namespace Core3LayersAPI.Core.Entities
{
    public partial class Person
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Cpf { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
