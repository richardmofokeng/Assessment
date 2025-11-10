using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Models
{
    public class Daily
    {
        public long Dt { get; set; }
        public Temp Temp { get; set; }
        public Weather[] Weather { get; set; }
        public int Humidity { get; set; }
        public double Wind_Speed { get; set; }
    }
}
