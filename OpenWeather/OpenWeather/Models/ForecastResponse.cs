using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Models
{
    public class ForecastResponse
    {
        public Daily[] Daily { get; set; }
    }
}
