using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TerrainApp.API.BusinessLogic.Terrain.GetPropertyNames
{
    public class PropertyTypeDto
    {
        public string PropType { get; set; } = string.Empty;
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
    }
}
