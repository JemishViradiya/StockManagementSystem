using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Display
    {
        public int customer_id { get; set; }
        public int stock_id { get; set; }
        public String customer_name { get; set; }
        public int quantity { get; set; }
        public int pending_quantity { get; set; }
        public Customer customer { get; set; }
        public Portfolio portfolio { get; set; }
        public Order order { get; set; }
    }
}
