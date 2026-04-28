namespace WMS_API.Models
{
    public class Party : BaseModel
    {
        public int PartyID { get; set; }
        public string PartyType { get; set; }
        public string PartyName { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
