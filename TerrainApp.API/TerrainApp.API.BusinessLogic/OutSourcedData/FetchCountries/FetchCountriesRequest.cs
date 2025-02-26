using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.BusinessLogic.OutSourcedData.FetchCountries
{
  public class FetchCountriesRequest : IRequest<FetchCountriesResponse>
  {
  }
}
