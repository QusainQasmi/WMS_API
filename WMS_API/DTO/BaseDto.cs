namespace WMS_API.DTO
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
