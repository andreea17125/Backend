using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.Domain.Terrain
{
    public class EnvData
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Rainfall { get; set; }

        public EnvData(double temperature, double humidity, double rainfall)
        {
            Temperature = temperature;
            Humidity = humidity;
            Rainfall = rainfall;
        }

        public override string ToString()
        {
            return $"Temperature: {Temperature}°C, Humidity: {Humidity}%, Rainfall: {Rainfall}mm";
        }
    }
}
