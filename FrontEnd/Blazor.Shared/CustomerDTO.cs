using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blazor.Shared
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Email is too long.")]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(7, ErrorMessage = "Postal code is too long.")]
        public string PostalCode { get; set; }
        [Required]
        public bool Stage { get; set; }
        [Required]
        public int Type { get; set; }
        public CustomerCompanyDTO Company { get; set; }
        public CustomerPersonDTO Person { get; set; }
        public List<CustomerPhoneDTO> Phones { get; set; }
    }
}
