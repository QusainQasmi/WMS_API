namespace WMS_API.Models
{
    public class Sys_Users : BaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int RoleId { get; set; }
        public int BranchId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsLocked { get; set; } = false;
    }
}
