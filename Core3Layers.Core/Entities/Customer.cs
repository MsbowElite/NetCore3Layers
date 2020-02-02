using System;
using System.Collections.Generic;

namespace Core3Layers.Core.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerPhones = new HashSet<CustomerPhones>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public bool Stage { get; set; }
        public byte Type { get; set; }

        public virtual Company Company { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<CustomerPhones> CustomerPhones { get; set; }
    }
}
