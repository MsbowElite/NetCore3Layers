using System;
using System.Collections.Generic;
using System.Text;

namespace Core3Layers.Core.Models
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public bool Stage { get; set; }
        public Byte Type { get; set; }
        public CustomerCompanyDTO Company { get; set; }
        public CustomerPersonDTO Person { get; set; }
    }
}
