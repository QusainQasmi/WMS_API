namespace WMS_API.Models
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        //public Supplier Supplier { get; set; }
        //public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }

}
