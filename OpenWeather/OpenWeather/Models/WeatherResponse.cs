using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Models
{
    public class WeatherResponse
    {
        public Main Main { get; set; }
        public Weather[] Weather { get; set; }
        public Wind Wind { get; set; }
        public Sys Sys { get; set; }
        public string Name { get; set; }
        public Coordinates Coord { get; set; }
    }
}
