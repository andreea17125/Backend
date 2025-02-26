using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace TerrainApp.API.CommonDomain
{
    public class City
    {
        public string Id = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; }
        public string Country { get; set; }


    }
}
