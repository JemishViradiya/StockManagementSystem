using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Stock
    {
        [Key]
        public int stock_id { get; set; }

        [Required(ErrorMessage = "Stock Name is mandatory")]
        public String stock_name { get; set; }

        [Range(0,500)]
        [Required(ErrorMessage = "Enter Stock Price and stock price must be between 0 and 500")]
        public double stock_price { get; set; }

        [Range(0,10000)]
        [Required(ErrorMessage ="Enter stock quantity")]
        public int stock_quantity { get; set; }

        


    }
}
