namespace WMS_API.Models
{
    public class SalesOrder
    {
        public int SalesOrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        //public Customer Customer { get; set; }
        //public ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }

}
