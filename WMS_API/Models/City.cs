using System.ComponentModel.DataAnnotations;

namespace WMS_API.Models
{
    public class City
    {
        [Key]
        public string CityName { get; set; }
        public Boolean Active { get; set; }
        public string CountryName { get; set; }
    }
}
