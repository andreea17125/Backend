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
            var Collection = dataBase.GetPropertiesCollection();
            var pipeline = new EmptyPipelineDefinition<Properties>();
            var data = Collection.Aggregate(pipeline).ToList();











        }
    }
}
