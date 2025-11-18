using System.ComponentModel.DataAnnotations;

namespace WMS_API.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [MaxLength(250)]
        public string SKU { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
