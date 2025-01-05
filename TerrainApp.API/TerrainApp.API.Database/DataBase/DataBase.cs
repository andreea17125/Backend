using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.Database.DataBase
{
    
    public class DataBase:IDataBase
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;
        private string Connection = "mongodb+srv://andreea17125:andreea17125@cluster0.6kkuj.mongodb.net/";
        private string DataBaseName = "TerrainDB";

        public DataBase()
        {
            this._mongoClient = new MongoClient(Connection);
            this._mongoDatabase = _mongoClient.GetDatabase(DataBaseName);

        }

        public IMongoDatabase GetMongoDatabase()
        {
           
            return  this._mongoDatabase;
        }

        public IMongoCollection<User> GetUserCollection()
        {
            return this._mongoDatabase.GetCollection<User>("Users");
        }
        public IMongoCollection<Terrain> GetTerrainCollection()
        {
            return this._mongoDatabase.GetCollection<Terrain>("Terrains");
        }
        public IMongoCollection<LoginHistory> GetLoginHistoryCollection()
        {
            return this._mongoDatabase.GetCollection<LoginHistory>("LoginHistory");
        }


    }
}
