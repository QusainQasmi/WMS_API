namespace WMS_API.DTO
{
    public class LoginRespDto
    {
        public string Token { get; set; }
        public string FullName { get; set; }
        public int UserId { get; set; }
        public int TenantId { get; set; }
    }
}
