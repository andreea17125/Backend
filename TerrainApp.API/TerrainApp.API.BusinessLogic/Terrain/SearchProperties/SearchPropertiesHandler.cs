using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.Terrain;
using static System.Net.Mime.MediaTypeNames;


namespace TerrainApp.API.BusinessLogic.Terrain.SearchProperties
{
  public class SearchPropertiesHandler : IRequestHandler<SearchPropertiesRequest, SearchPropertiesResponse>
  {
    private readonly IDataBase dataBase;

    public SearchPropertiesHandler(IDataBase dataBase)
    {
      this.dataBase = dataBase;
    }
    public async Task<SearchPropertiesResponse> Handle(SearchPropertiesRequest request, CancellationToken cancellationToken)
    {
      var collection = dataBase.GetPropertiesCollection();

      var filterBuilder = Builders<Properties>.Filter;

      var filter = filterBuilder.Gte(x => x.Sale_Price, request.Sale_Price_Start) &
                   filterBuilder.Lte(x => x.Sale_Price, request.Sale_Price_End) &
                   filterBuilder.Gte(x => x.Rooms, request.Rooms_Start) &
                   filterBuilder.Lte(x => x.Rooms, request.Rooms_End)&
                   filterBuilder.Gte(x => x.HBath, request.HBath_Start) &
                    filterBuilder.Lte(x => x.HBath, request.HBath_End);

            if (!string.IsNullOrEmpty(request.PropType))
      {
        filter &= filterBuilder.Eq(x => x.PropType, request.PropType);
      }

      var projection = Builders<Properties>.Projection
          .Include(x => x.PropType)
          .Include(x => x.Sale_Price)
          .Include(x => x.Rooms);

      var docs = await collection.Aggregate()
          .Match(filter)
          .Project(projection).Skip(request.SkipCount*request.TakeCount)
          .Limit(request.TakeCount)
          .As<PropertieDto>()
          .ToListAsync(cancellationToken);

      return new SearchPropertiesResponse
      {
        PropertieDto = docs
      };


    }
  }
}
