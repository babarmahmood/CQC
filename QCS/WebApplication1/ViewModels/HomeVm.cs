using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QcsWeb.ViewModels
{
    public class HomeVm
    {
        [Required]
        public string Name { get; set; }
    }
}
