using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.CommonDomain
{
  public class Country
  {
    public string Id = ObjectId.GenerateNewId().ToString();
    public string Name {  get; set; }

    public string Code {  get; set; }
  }
}
