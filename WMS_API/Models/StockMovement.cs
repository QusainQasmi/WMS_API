using System.ComponentModel.DataAnnotations;

namespace WMS_API.Models
{
    public class StockMovements
    {
        [Key]
        public int MovementId { get; set; }
        public int ProductId { get; set; }
        [MaxLength(100)]
        //public string ProductName { get; set; } = string.Empty;
        public int FromLocationId { get; set; }
        [MaxLength(100)]
        //public string FromLocationName { get; set; } = string.Empty;
        public int ToLocationId { get; set; }
        [MaxLength(100)]
        //public string ToLocationName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        [MaxLength(100), Required]
        public string MovementType { get; set; }
        public DateTime MovementDate { get; set; }

    }

}
