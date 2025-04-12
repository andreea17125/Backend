using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.BusinessLogic.Terrain.SearchProperties
{
    public class SearchPropertiesResponse
    {
       public List<PropertieDto> PropertieDto { get; set; } = new List<PropertieDto>();
    }
}
