using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TerrainApp.API.BusinessLogic.Users.Register;

namespace TerrainApp.API.BusinessLogic.Terrain.SearchProperties
{
    public class SearchPropertiesRequest : IRequest<SearchPropertiesResponse>
    {

        public int Year_Built_Start { get; set; } = -20000;
        public int Year_Built_End { get; set; } = 1000000;

        public int Lot_Size_Start { get; set; } = -20000;
        public int Lot_Size_End { get; set; } = 1000000;

        public int Sale_Price_Start { get; set; } = -20000;

        public int Sale_Price_End { get; set; } = 1000000;

        public int Rooms_Start { get; set; } = -20000;
        public int Rooms_End { get; set; } = 1000000;
        public int FBath_Start { get; set; } = -20000;
        public int FBath_End { get; set; } = 1000000;

        public int HBath_Start { get; set; } = -20000;

        public int HBath_End { get; set; } = 1000000;



    }
}
