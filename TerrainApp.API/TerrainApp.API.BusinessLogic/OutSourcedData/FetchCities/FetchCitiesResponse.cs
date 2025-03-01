using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainApp.API.CommonDomain;

namespace TerrainApp.API.BusinessLogic.OutSourcedData.FetchCities
{
    
        public class FetchCitiesResponse : ResponseDto
        {
            public List<string> Cities { get; set; } = new List<string>();
        }
    }


