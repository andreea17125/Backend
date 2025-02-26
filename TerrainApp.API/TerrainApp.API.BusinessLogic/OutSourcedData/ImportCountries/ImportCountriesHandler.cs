using MediatR;
using TerrainApp.API.DataAbstraction.IDataBase;

namespace TerrainApp.API.BusinessLogic.OutSourcedData.ImportCountries
{
  public class ImportCountriesHandler : IRequestHandler<ImportCountriesRequest, ImportCountriesResponse>
  {
    private IDataBase dataBase;

    public ImportCountriesHandler(IDataBase dataBase) {
      this.dataBase = dataBase;
    }
    public async Task<ImportCountriesResponse> Handle(ImportCountriesRequest request, CancellationToken cancellationToken)
    {
      await this.dataBase.GetCountriesCollection().InsertManyAsync(request.Countries, cancellationToken: cancellationToken);
      return new ImportCountriesResponse
      {
        Message = "Success",
        StatusCode = System.Net.HttpStatusCode.Created,
      };
    }
  }
}
