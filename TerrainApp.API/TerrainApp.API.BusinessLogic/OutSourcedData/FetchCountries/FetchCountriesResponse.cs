using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainApp.API.CommonDomain;

namespace TerrainApp.API.BusinessLogic.OutSourcedData.FetchCountries
{
  public class FetchCountriesResponse : ResponseDto
  {
    public List<Country> Countries { get; set; } = new List<Country>();
  }
}
