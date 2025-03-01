using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TerrainApp.API.BusinessLogic.OutSourcedData.ImportCountries;
using TerrainApp.API.CommonDomain;

namespace TerrainApp.API.BusinessLogic.OutSourcedData.ImportCities
{
   
        public class ImportCitiesRequest : IRequest<ImportCitiesResponse>
        {
            public List<City> Cities { get; set; } = new List<City>();
        }
    

}
