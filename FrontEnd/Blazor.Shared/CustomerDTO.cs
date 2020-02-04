using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Shared
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public bool Stage { get; set; }
        public int Type { get; set; }
        public CustomerCompanyDTO Company { get; set; }
        public CustomerPersonDTO Person { get; set; }
        public List<CustomerPhoneDTO> Phones { get; set; }
    }
}
