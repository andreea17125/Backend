using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.CommonDomain
{
    public class Location
    {
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location(string country, string city, string address, double latitude, double longitude)
        {
            Country = country;
            City = city;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
