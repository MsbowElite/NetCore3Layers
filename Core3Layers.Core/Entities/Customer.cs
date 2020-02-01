using System;
using System.Collections.Generic;

namespace Core3LayersAPI.Core.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Company = new HashSet<Company>();
            CustomerPhones = new HashSet<CustomerPhones>();
            Person = new HashSet<Person>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public bool Stage { get; set; }
        public byte Type { get; set; }

        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<CustomerPhones> CustomerPhones { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }
}
