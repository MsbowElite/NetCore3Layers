using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Blazor.Shared
{
    public class CustomerPersonDTO
    {
        [Required]
        [StringLength(11, ErrorMessage = "CPF is too long.")]
        public string CPF { get; set; }
    }
}
