using Assignment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Fevourite
    {
        [Key]
        public int fevourite_id { get; set; }

        [ForeignKey("Customer")]
        public int customer_id { get; set; }

        public Customer customer { get; set; }

        
        [ForeignKey("Stock")]
        public int stock_id { get; set; }

    }
}
