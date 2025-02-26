using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TerrainApp.API.BusinessLogic.OutSourcedData.FetchCities
{
    
        public class FetchCitiesRequest : IRequest<FetchCitiesResponse>
        {
            public string Country { get; set; }
        }
    }


