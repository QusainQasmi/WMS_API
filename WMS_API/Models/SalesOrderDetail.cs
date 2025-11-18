namespace WMS_API.Models
{
    public class SalesOrderDetail
    {
        public int SalesOrderDetailId { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public SalesOrder SalesOrder { get; set; }
        public Product Product { get; set; }
    }

}
