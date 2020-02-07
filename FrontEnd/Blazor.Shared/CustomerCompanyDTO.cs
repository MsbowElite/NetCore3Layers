using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Blazor.Shared
{
    public class CustomerCompanyDTO
    {
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        [Required]
        [StringLength(14, ErrorMessage = "Name is too long.")]
        public string CNPJ { get; set; }
    }
}
