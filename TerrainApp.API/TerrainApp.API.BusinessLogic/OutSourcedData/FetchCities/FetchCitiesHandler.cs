using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using TerrainApp.API.CommonDomain;
using TerrainApp.API.DataAbstraction.IDataBase;

namespace TerrainApp.API.BusinessLogic.OutSourcedData.FetchCities
{
    public class FetchCitiesHandler : IRequestHandler<FetchCitiesRequest, FetchCitiesResponse>
    {
        private readonly IDataBase dataBase;

        public FetchCitiesHandler(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        public async Task<FetchCitiesResponse> Handle(FetchCitiesRequest request, CancellationToken cancellationToken)
        {
            var filter = Builders<City>.Filter.Eq(city => city.Country, request.Country);
            List<City> cities = await this.dataBase.GetCitiesCollection()
                .Find(filter)
                .ToListAsync(cancellationToken);

            return new FetchCitiesResponse
            {
                Cities = cities.Select(c => c.Name).ToList(),
                Message = "Success",
                StatusCode = HttpStatusCode.OK,
            };
        }
    }
}
