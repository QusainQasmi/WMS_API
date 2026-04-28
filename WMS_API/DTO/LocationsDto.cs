using AutoMapper;
using System.ComponentModel.DataAnnotations;
using WMS_API.DTO;
using WMS_API.Mapper;
using WMS_API.Models;

namespace WMS_API.DTOs
{
    public class LocationDto : BaseDto, IMapFrom<Location>
    {
        [Required]
        [MaxLength(10)]
        public string UnCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string UnName { get; set; } = string.Empty;

        [MaxLength(250)]
        public string UnAddress { get; set; } = string.Empty;

        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [MaxLength(100)]
        public string UnState { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool IsPort { get; set; } = false;
        public bool IsAirport { get; set; } = false;
        public bool IsWarehouse { get; set; } = false;
        public bool IsPickupPoint { get; set; } = false;
        public bool IsDeliveryPoint { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Location, LocationDto>().ReverseMap();
        }
    }
}