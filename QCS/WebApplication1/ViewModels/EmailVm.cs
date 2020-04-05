using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QcsWeb.ViewModels
{
    public class EmailVm
    {
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}",
         ErrorMessage ="Please enter valid email address")]
        public string EmailAddress { get; set; }
    }
}
