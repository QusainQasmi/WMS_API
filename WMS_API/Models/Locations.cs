using System.ComponentModel.DataAnnotations;

namespace WMS_API.Models
{
    public class Locations
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        public int WarehouseId { get; set; }
        [MaxLength(255)]
        public string WarehouseName { get; set; } = string.Empty;
        [MaxLength(255)]
        public string LocationCode { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }

}
