namespace TerrainApp.API.Domain.UserDomain
{
    public class Location
    {
        private string Country;
        private string City;
        private string Address;
        private string PostalCode;
        private int StreetNumber;
       

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