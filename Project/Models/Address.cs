using Project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Address
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string streetName { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        [StringLength(6)]
        public string zipCode { get; set; }

        [ForeignKey("Customer")]

        public int customerId { get; set; }
        public Customer customer { get; set; }
    }
}