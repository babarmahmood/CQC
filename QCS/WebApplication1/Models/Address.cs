using QcsWeb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QcsWeb.Models
{
    public class Address 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BuildingAndStreet { get; set; }
        public string TownOrCity { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public DateTime DateCreated { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
       
    }
}
