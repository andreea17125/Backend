using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TerrainApp.API.Domain.Terrain
{
  public class Properties
  {
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }


    [BsonElement("PropType")]
    public string PropType { get; set; } = String.Empty;
    public string Taxkey { get; set; } = String.Empty;

    public string Address { get; set; }

    public string CondoProject { get; set; } = String.Empty;

    public int District { get; set; } = 0;
    public string Nbhd { get; set; } = String.Empty;
    public string Style { get; set; } = String.Empty;

    public string ExtWall { get; set; } = String.Empty;
    public int Stories { get; set; } = 0;
    public int Year_Built { get; set; } = 0;
    [BsonElement("Nr_of_rms")]

    public int Rooms { get; set; } = 0;

    public string FinishedSqFt { get; set; } = String.Empty;

    public int Units { get; set; } = 0;

    public int Bdrms { get; set; } = 0;
    public int FBath { get; set; } = 0;

    public int HBath { get; set; } = 0;

    public int Lotsize { get; set; } = 0;

    public DateTime Sale_Date { get; set; } = DateTime.MinValue;

    [BsonElement("Sale_price")]

    public int Sale_Price { get; set; } = 0;


  }
}
