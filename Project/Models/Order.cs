using Project.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        [Range(typeof(decimal), "0", "1000")]
        public double totalAmount { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime orderDate { get; set; }

        [Required]
        public int quantity { get; set; }

        [ForeignKey("Customer")]
        public int customerId { get; set; }
        public virtual Customer customer { get; set; }

       

        [ForeignKey("Stock")]
        public int stock_id { get; set; }
        public virtual Stock stock { get; set; }

        public String status { get; set; }

    }
}