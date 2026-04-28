namespace WMS_API.Models
{
    public class STP_Roles : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
