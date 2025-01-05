using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.Domain.Terrain
{
    public class ProximityData
    {
        public double DistanceToWater { get; set; }
        public double DistanceToUrbanArea { get; set; }

        public ProximityData(double distanceToWater, double distanceToUrbanArea)
        {
            DistanceToWater = distanceToWater;
            DistanceToUrbanArea = distanceToUrbanArea;
        }

        public override string ToString()
        {
            return $"Water: {DistanceToWater} km, Urban Area: {DistanceToUrbanArea} km";
        }
    }
}
