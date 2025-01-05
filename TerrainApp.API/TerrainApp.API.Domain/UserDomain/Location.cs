namespace TerrainApp.API.Domain.UserDomain
{
    public class Location
    {
        private string country;
        private string city;
        private string address;
        private double latitude;
        private double longitude;

        public Location(string country, string city, string address, double latitude, double longitude)
        {
            this.country = country;
            this.city = city;
            this.address = address;
            this.latitude = latitude;
            this.longitude = longitude;
        }
        public Location()
        {
            
        }
    }
}