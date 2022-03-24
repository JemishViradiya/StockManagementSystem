using Assignment.Models;
using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }
        [Required]
        public string customer_name { get; set; }
       
        [StringLength(10)]
        [Required]
        [DisplayName("Mobile Number")]
        public String contact_number { get; set; }

        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string customer_email { get; set; }

    
        public string password { get; set; }
        public Address address { get; set; }
        public ICollection<Order> Orders { get; set; }

        public ICollection<Stock> stocks { get; set; }

      


    }
}
