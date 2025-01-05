using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using TerrainApp.API.DataAbstraction.Repository;
using TerrainApp.API.Database.DataBase;
using TerrainApp.API.Domain.UserDomain;
using ZstdSharp.Unsafe;

namespace TerrainApp.API.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private DataBase db = null;

        public UserRepository(DataBase dboriginal) {
        db= dboriginal;
        }
        public async Task<bool> Delete(string id)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id , id);
            await this.db.GetUserCollection().DeleteOneAsync(filter);
            return true;
        }

        public async Task<List<User>> GetAll()
        {
            var filter = Builders<User>.Filter.Empty;
            var users = await this.db.GetUserCollection().Find(filter).ToListAsync();
            return users;


        }

        public async Task<User> GetById(string id)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, id);
            var user = await this.db.GetUserCollection().Find(filter).FirstOrDefaultAsync();
            return user;
        }

        public async Task<string> Insert(User document)
        {
           await  this.db.GetUserCollection().InsertOneAsync(document);
            return document.Id;
        }

        public async Task<bool> Update(User document)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id,document.Id);
            var update = Builders<User>.Update.Set(x => x.FirstName, document.FirstName).Set(x => x.LastName, document.LastName);
            await this.db.GetUserCollection().UpdateOneAsync(filter,update);
            return true;
        }
    }
}
