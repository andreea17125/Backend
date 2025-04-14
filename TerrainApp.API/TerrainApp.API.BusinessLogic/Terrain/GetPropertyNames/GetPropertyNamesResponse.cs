using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.BusinessLogic.Terrain.GetPropertyNames
{
    public class GetPropertyNamesResponse
    {
        public List<PropertyTypeDto> PropertyTypeDto { get; set; } = new List<PropertyTypeDto>();

    }
}
