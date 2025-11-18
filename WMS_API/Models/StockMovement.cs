using System.ComponentModel.DataAnnotations;

namespace WMS_API.Models
{
    public class StockMovement
    {
        [Key]
        public int MovementId { get; set; }
        public int ProductId { get; set; }
        [MaxLength(100)]
        public int ProductName { get; set; }
        public int FromLocationId { get; set; }
        [MaxLength(100)]
        public int FromLocationName { get; set; }
        public int ToLocationId { get; set; }
        [MaxLength(100)]
        public int ToLocationName { get; set; }
        public int Quantity { get; set; }
        [MaxLength(100)]
        public int MovementType { get; set; }
        public DateTime MovementDate { get; set; }

    }

}
