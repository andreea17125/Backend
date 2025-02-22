namespace TerrainApp.API.Domain.UserDomain
{
    public class Location
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int StreetNumber { get; set; }
       

        public Location(string Country, string CIty, string Address,int StreetNumber,string ZipCode)
        {
            this.Country = Country;
            this.City = City;
            this.Address = Address;
            this.PostalCode = PostalCode;
            this.StreetNumber = StreetNumber;
          
        }
        public Location()
        {
            
        }
    }
}