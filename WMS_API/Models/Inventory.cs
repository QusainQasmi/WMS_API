using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_API.Models
{
    [Table("Inventory")]
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [MaxLength(255)]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public int LocationId { get; set; }
        [MaxLength(255)]
        public string LocationCode { get; set; } = string.Empty;
        [Required]
        public int Quantity { get; set; }
    }
}
