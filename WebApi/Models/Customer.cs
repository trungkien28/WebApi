using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("customer")]
    public class Customer
    {
        [Key, Column("id")]
        public int ID { get; set; }
        [Column("customer_name")]
        public string Name { get; set; }
        [Column("age")]
        public int Age { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
        [Column("mobile")]
        public string Phone { get; set; }
        [Column("email")]
        public string Email { get; set; }
    }
}