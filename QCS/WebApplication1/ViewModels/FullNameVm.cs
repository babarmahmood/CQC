using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QcsWeb.ViewModels
{
    public class FullNameVm
    {
        [Required(ErrorMessage = "Please enter your full Name")]
        [MaxLength(50, ErrorMessage = "Full name must be 50 charcaters or less.")]
        public string FullName { get; set; }
    }
}
