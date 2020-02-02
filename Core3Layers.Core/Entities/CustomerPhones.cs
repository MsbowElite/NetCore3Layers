using System;
using System.Collections.Generic;

namespace Core3Layers.Core.Entities
{
    public partial class CustomerPhones
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Phone { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
