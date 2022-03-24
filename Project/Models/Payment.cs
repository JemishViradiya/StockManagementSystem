using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Payment
    {
        [Key]
        public int payment_id { get; set; }

        public String payment_type { get; set; }

        [Required]
        [MinLength(1)][MaxLength(10)]
        [StringLength(10)]
        public String card_number { get; set; }

        [Required]
        public int card_cvv { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{MM/YY}")]
        public DateTime card_expiry { get; set; }

        [ForeignKey("Customer")]
        public int customer_id { get; set; }
         
       
        
        [ForeignKey("Order")]
        public int order_id { get; set; }

       
       
        

    }
}
