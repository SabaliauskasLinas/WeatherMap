using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Core.Entities
{
    public class WeatherDescription
    {
        public string Icon { get; set; }

        [JsonProperty("description")]
        public string Text { get; set; }
    }
}
