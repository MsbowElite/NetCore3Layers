using System;
using System.Collections.Generic;

namespace Core3Layers.Core.Entities
{
    public partial class Person
    {
        public Guid CustomerId { get; set; }
        public string Cpf { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
