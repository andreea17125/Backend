﻿using MongoDB.Driver;
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

    //public IMongoCollection<> GetCitiesCollection();
  }
}
