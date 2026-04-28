using Microsoft.AspNetCore.Mvc;

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        [HttpGet("getCountries")]
        public IActionResult GetCountries()
        {
            var countries = new string[]
            {
                "USA","Canada","Mexico","UK","Germany","France","Italy","Spain","Netherlands","Belgium",
                "Switzerland","Austria","Sweden","Norway","Denmark","Finland","Ireland","Portugal","Greece","Turkey",
                "Russia","China","Japan","South Korea","Singapore","Malaysia","Thailand","Indonesia","Vietnam",
                "Australia","New Zealand","Brazil","Argentina","Chile","Colombia","South Africa","Egypt","Nigeria","Kenya",
                "UAE","Saudi Arabia","Qatar","Kuwait","Oman","Pakistan","Bangladesh","Sri Lanka","Nepal","Maldives",
                "India"
            };
            return Ok(countries);
        }

        [HttpGet("getCities")]
        public IActionResult GetCities([FromQuery] string country)
        {
            var cities = new Dictionary<string, string[]>
            {
                { "Pakistan", new[]
                    {
                        "Karachi",
                        "Lahore",
                        "Islamabad",
                        "Rawalpindi",
                        "Faisalabad",
                        "Multan",
                        "Peshawar",
                        "Quetta",
                        "Sialkot",
                        "Gujranwala",
                        "Hyderabad",
                        "Sukkur",
                        "Bahawalpur",
                        "Larkana",
                        "Sargodha",
                        "Sheikhupura",
                        "Mardan",
                        "Kasur",
                        "Okara",
                        "Mirpur Khas"
                    }
                },
                { "India", new[] { "Mumbai","Delhi","Bangalore","Hyderabad","Chennai","Kolkata","Pune","Ahmedabad","Jaipur","Lucknow" } },
                { "USA", new[] { "New York","Los Angeles","Chicago","Houston","Miami" } },
                { "Canada", new[] { "Toronto","Vancouver","Montreal","Calgary","Ottawa" } },
                { "Mexico", new[] { "Mexico City","Guadalajara","Monterrey" } },
                { "UK", new[] { "London","Manchester","Birmingham","Liverpool" } },
                { "Germany", new[] { "Berlin","Munich","Frankfurt","Hamburg" } },
                { "France", new[] { "Paris","Lyon","Marseille","Nice" } },
                { "Italy", new[] { "Rome","Milan","Venice","Naples" } },
                { "Spain", new[] { "Madrid","Barcelona","Valencia" } },
                { "Netherlands", new[] { "Amsterdam","Rotterdam","The Hague" } },
                { "Belgium", new[] { "Brussels","Antwerp","Ghent" } },
                { "Switzerland", new[] { "Zurich","Geneva","Bern" } },
                { "Austria", new[] { "Vienna","Salzburg","Graz" } },
                { "Sweden", new[] { "Stockholm","Gothenburg","Malmo" } },
                { "Norway", new[] { "Oslo","Bergen","Trondheim" } },
                { "Denmark", new[] { "Copenhagen","Aarhus","Odense" } },
                { "Finland", new[] { "Helsinki","Espoo","Tampere" } },
                { "Ireland", new[] { "Dublin","Cork","Galway" } },
                { "Portugal", new[] { "Lisbon","Porto","Braga" } },
                { "Greece", new[] { "Athens","Thessaloniki","Patras" } },
                { "Turkey", new[] { "Istanbul","Ankara","Izmir" } },
                { "Russia", new[] { "Moscow","Saint Petersburg","Novosibirsk" } },
                { "China", new[] { "Beijing","Shanghai","Shenzhen","Guangzhou" } },
                { "Japan", new[] { "Tokyo","Osaka","Kyoto" } },
                { "South Korea", new[] { "Seoul","Busan","Incheon" } },
                { "Singapore", new[] { "Singapore" } },
                { "Malaysia", new[] { "Kuala Lumpur","Penang","Johor Bahru" } },
                { "Thailand", new[] { "Bangkok","Chiang Mai","Phuket" } },
                { "Indonesia", new[] { "Jakarta","Bali","Surabaya" } },
                { "Vietnam", new[] { "Hanoi","Ho Chi Minh City","Da Nang" } },
                { "Australia", new[] { "Sydney","Melbourne","Brisbane","Perth" } },
                { "New Zealand", new[] { "Auckland","Wellington","Christchurch" } },
                { "Brazil", new[] { "Sao Paulo","Rio de Janeiro","Brasilia" } },
                { "Argentina", new[] { "Buenos Aires","Cordoba","Rosario" } },
                { "Chile", new[] { "Santiago","Valparaiso","Concepcion" } },
                { "Colombia", new[] { "Bogota","Medellin","Cali" } },
                { "South Africa", new[] { "Johannesburg","Cape Town","Durban" } },
                { "Egypt", new[] { "Cairo","Alexandria","Giza" } },
                { "Nigeria", new[] { "Lagos","Abuja","Kano" } },
                { "Kenya", new[] { "Nairobi","Mombasa","Kisumu" } },
                { "UAE", new[] { "Dubai","Abu Dhabi","Sharjah" } },
                { "Saudi Arabia", new[] { "Riyadh","Jeddah","Dammam" } },
                { "Qatar", new[] { "Doha" } },
                { "Kuwait", new[] { "Kuwait City" } },
                { "Oman", new[] { "Muscat" } },
                { "Bangladesh", new[] { "Dhaka","Chittagong","Khulna" } },
                { "Sri Lanka", new[] { "Colombo","Kandy","Galle" } },
                { "Nepal", new[] { "Kathmandu","Pokhara","Biratnagar" } },
                { "Maldives", new[] { "Malé" } }
            };

            if (!string.IsNullOrEmpty(country) && cities.ContainsKey(country))
            {
                return Ok(cities[country]);
            }

            // Default: all cities combined
            return Ok(cities.Values.SelectMany(x => x));
        }
    }
}
