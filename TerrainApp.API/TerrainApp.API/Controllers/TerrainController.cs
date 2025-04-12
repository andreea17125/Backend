using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TerrainApp.API.BusinessLogic.Terrain.SearchProperties;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.Terrain;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TerrainController : ControllerBase
  {
    IMongoCollection<Terrain> _terrains;
    private readonly IMediator mediator;
    public TerrainController(IDataBase dataBase, IMediator mediator)
    {
      this._terrains = dataBase.GetMongoDatabase().GetCollection<Terrain>("Terrains");
      this.mediator = mediator;
    }

    [HttpPost("SearchProperties")]
    public async Task<ActionResult> SearchProperties(SearchPropertiesRequest request)
    {
      var response = await this.mediator.Send(request);
      return this.Ok(response);
    }

    [HttpPost("CreateTerrain")]
    public async Task<ActionResult> CreateTerrain(Terrain terrain)
    {
      await this._terrains.InsertOneAsync(terrain);
      return this.Ok(terrain);

    }
    [HttpPut("UpdateTerrain")]
    public async Task<ActionResult> UpdateTerrain(Terrain terrain)
    {
      var filter = Builders<Terrain>.Filter.Eq(x => x.Id, terrain.Id);
      await this._terrains.ReplaceOneAsync(filter, terrain);
      return this.Ok(terrain);
    }
    [HttpDelete("DeleteTerrain/{id}")]
    public async Task<ActionResult> DeleteTerrain(string id)
    {
      var filter = Builders<Terrain>.Filter.Eq(x => x.Id, id);
      await this._terrains.DeleteOneAsync(filter);
      return this.Ok();
    }
    [HttpGet("GetTerrain/{id}")]
    public async Task<ActionResult> GetTerrain(string id)
    {

      var filter = Builders<Terrain>.Filter.Eq(x => x.Id, id);
      var Terrain = await this._terrains.Find(filter).FirstOrDefaultAsync();
      return this.Ok(Terrain);
    }
    [HttpGet("GetAllTerrains")]
    public async Task<ActionResult> GetAllTerrains()
    {

      var filter = Builders<Terrain>.Filter.Empty;
      var Terrain = await this._terrains.Find(filter).ToListAsync();

      return this.Ok(Terrain);
    }
  }
}
