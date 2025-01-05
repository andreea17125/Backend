using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using TerrainApp.API.Domain.Terrain;

public class Terrain
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TerrainType TerrainType { get; set; }
    public double Area { get; set; }
    public double Elevation { get; set; } 
    public string Location { get; set; } 
    public double Humidity { get; set; } 
    public double Temperature { get; set; } 
    public bool IsAvailable { get; set; } 

    public Terrain()
    {
        this.Id = ObjectId.GenerateNewId().ToString();
    }
}



