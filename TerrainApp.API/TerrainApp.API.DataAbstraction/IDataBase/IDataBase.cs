using MongoDB.Driver;
using TerrainApp.API.CommonDomain;
using TerrainApp.API.Domain;
using TerrainApp.API.Domain.RequestRegister;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.DataAbstraction.IDataBase
{
  public interface IDataBase
  {
    IMongoDatabase GetMongoDatabase();
    public IMongoCollection<User> GetUserCollection();

    public IMongoCollection<Terrain> GetTerrainCollection();

    public IMongoCollection<LoginHistory> GetLoginHistoryCollection();

    public IMongoCollection<UserRegisterRequest> GetUserRegistrationCollection();

    public IMongoCollection<Country> GetCountriesCollection();

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    public IMongoCollection<City> GetCitiesCollection();


=======
>>>>>>> 4cd1c94e815af3b87623d10b2d75a7b9deeff813
=======
>>>>>>> 4cd1c94e815af3b87623d10b2d75a7b9deeff813
=======
>>>>>>> 4cd1c94e815af3b87623d10b2d75a7b9deeff813
=======
>>>>>>> 4cd1c94e815af3b87623d10b2d75a7b9deeff813
    //public IMongoCollection<> GetCitiesCollection();
  }
}
