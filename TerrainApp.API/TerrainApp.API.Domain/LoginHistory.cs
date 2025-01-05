using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TerrainApp.API.Domain
{
   public class LoginHistory
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Refreshtoken { get; set; }

        public LoginHistory()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }

    }
}
