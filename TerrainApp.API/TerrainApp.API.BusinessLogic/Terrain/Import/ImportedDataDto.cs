using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.BusinessLogic.Terrain.Import
{
    public class ImportedDataDto
    {
        public int PropertyID { get; set; } 


        public string PropertyType { get; set; } = String.Empty;
        public string taxKey { get; set; } = String.Empty;

        public string Address { get; set; } 

        public string CondoProject { get; set; } = String.Empty;

        public int District { get; set; } = 0;
        public string nbhd { get; set; } = String.Empty;
        public string Style { get; set; } = String.Empty;

         public  string ExtWall { get; set; } = String.Empty;
        public int Stories { get; set; } = 0;
        public int Year_Built { get; set; } = 0;
        public int Rooms { get; set; } = 0;

        public string FinishedSqFt { get; set; } = String.Empty;

        public int Units { get; set; } = 0;

        public int Bdrms { get; set; } = 0;
        public int FBath { get; set; } = 0;

        public int HBath { get; set; } = 0;

        public int Lotsize { get; set; } = 0;

        public DateTime Sale_Date { get; set; } = DateTime.MinValue;

        public int Sale_Price { get; set; } = 0;




    }   
}
