using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_API.Models
{
    [Table("Locations")]
    public class Location : BaseModel
    {
        [Required]
        [StringLength(10)]
        public string UnCode { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string UnName { get; set; } = string.Empty;

        [StringLength(250)]
        public string? UnAddress { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(100)]
        public string? UnState { get; set; }

        [StringLength(20)]
        public string? PostalCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,7)")]
        public decimal? Latitude { get; set; }

        [Column(TypeName = "decimal(10,7)")]
        public decimal? Longitude { get; set; }
        public bool IsPort { get; set; } = false;
        public bool IsAirport { get; set; } = false;
        public bool IsWarehouse { get; set; } = false;
        public bool IsPickupPoint { get; set; } = false;
        public bool IsDeliveryPoint { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }


}
