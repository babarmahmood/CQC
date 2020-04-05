using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QcsWeb.ViewModels
{
    public class AddressVm
    {
        public string BuildindAndStreet { get; set; }
        public string TownOrCity { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }
}
