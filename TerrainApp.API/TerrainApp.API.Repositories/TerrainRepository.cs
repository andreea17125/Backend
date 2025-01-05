using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using TerrainApp.API.Database.DataBase;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.Repositories
{
   public class TerrainRepository
    {
        private DataBase db = null;

        public TerrainRepository(DataBase dboriginal)
        {
            db = dboriginal;
        }
        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Terrain>.Filter.Eq(x => x.Id, id);
            await this.db.GetTerrainCollection().DeleteOneAsync(filter);
            return true;
        }

        public async Task<List<Terrain>> GetAll()
        {
            var filter = Builders<Terrain>.Filter.Empty;
            var terrains = await this.db.GetTerrainCollection().Find(filter).ToListAsync();
            return terrains;


        }

        public async Task<Terrain> GetById(string id)
        {
            var filter = Builders<Terrain>.Filter.Eq(x => x.Id, id);
            var teren = await this.db.GetTerrainCollection().Find(filter).FirstOrDefaultAsync();
            return teren;
        }

        public async Task<string> Insert(Terrain document)
        {
            await this.db.GetTerrainCollection().InsertOneAsync(document);
            return document.Id;
        }

        public async Task<bool> Update(Terrain document)
        {
            var filter = Builders<Terrain>.Filter.Eq(x => x.Id, document.Id);
            var update = Builders<Terrain>.Update.Set(x => x.Name, document.Name).Set(x => x.Description, document.Description);
            await this.db.GetTerrainCollection().UpdateOneAsync(filter, update);
            return true;
        }
    }
}
