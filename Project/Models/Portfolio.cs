using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Portfolio
    {   
        [Key]
        public int portfolio_id { get; set; }

        [ForeignKey("Customer")]
        public int client_id { get; set; }
       
        public int portfolio_size { get; set; }

        [ForeignKey("Stock")]
        public int stock_id { get; set; }

        public virtual Stock Stock { get; set; }
        
    }
}
