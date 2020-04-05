using QcsWeb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QcsWeb.Models
{
    public class LightFeedback 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsHappy { get; set; }
        public int BrightnessLevel { get; set; }
        public DateTime DateCreated { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}

