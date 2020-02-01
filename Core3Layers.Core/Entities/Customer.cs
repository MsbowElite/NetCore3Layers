using System;
using System.Collections.Generic;

namespace Core3Layers.Core.Entities
{
    public partial class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public bool Stage { get; set; }
        public byte Type { get; set; }

        public virtual Company Company { get; set; }
        public virtual CustomerPhones CustomerPhones { get; set; }
        public virtual Person Person { get; set; }
    }
}
