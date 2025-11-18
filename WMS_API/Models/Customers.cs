using System.ComponentModel.DataAnnotations;

namespace WMS_API.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required, MaxLength(200)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        [MaxLength(200)]
        public string Person { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
    }

}
