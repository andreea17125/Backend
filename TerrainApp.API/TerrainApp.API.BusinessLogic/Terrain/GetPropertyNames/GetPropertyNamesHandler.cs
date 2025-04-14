using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using TerrainApp.API.BusinessLogic.Terrain.Import;
using TerrainApp.API.BusinessLogic.Terrain.SearchProperties;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.Terrain;

namespace TerrainApp.API.BusinessLogic.Terrain.GetPropertyNames
{

  
    public class GetPropertyNamesHandler : IRequestHandler<GetPropertyNamesRequest, GetPropertyNamesResponse>
    {
        private readonly IDataBase dataBase;
        public GetPropertyNamesHandler(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }
        public async Task<GetPropertyNamesResponse>Handle(GetPropertyNamesRequest request, CancellationToken cancellationToken)
        {

            var collection = dataBase.GetPropertiesCollection();

            var docs = await collection.Aggregate()
                .Group(
                    key => key.PropType,
                    g => new { PropType = g.Key }
                )
                .Project(x => new PropertyTypeDto
                {
                    PropType = x.PropType
                })
                .ToListAsync(cancellationToken);

            return new GetPropertyNamesResponse
            {
                PropertyTypeDto = docs
            };


        }
    }
}
