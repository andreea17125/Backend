using MediatR;
using TerrainApp.API.CommonDomain;

namespace TerrainApp.API.BusinessLogic.OutSourcedData.ImportCountries
{
  public class ImportCountriesRequest : IRequest<ImportCountriesResponse>
  {
    public List<Country> Countries { get; set; } = new List<Country>();
  }
}
