using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainApp.API.CommonDomain;
using TerrainApp.API.DataAbstraction.IDataBase;

namespace TerrainApp.API.BusinessLogic.OutSourcedData.FetchCountries
{
  public class FetchCountriesHandler : IRequestHandler<FetchCountriesRequest, FetchCountriesResponse>
  {
    private readonly IDataBase dataBase;
    public FetchCountriesHandler(IDataBase dataBase)
    {
      this.dataBase = dataBase;
    }
    public async Task<FetchCountriesResponse> Handle(FetchCountriesRequest request, CancellationToken cancellationToken)
    {
      List<Country> countries = await this.dataBase.GetCountriesCollection().Find(Builders<Country>.Filter.Empty).ToListAsync(cancellationToken);
      return new FetchCountriesResponse
      {
        Countries = countries,
        Message = "Success",
        StatusCode = System.Net.HttpStatusCode.OK,
      };
    }
  }
}
