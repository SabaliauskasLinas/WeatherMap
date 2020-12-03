using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class WeatherDetails
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        public DateTime Sunset { get; set; }

        public DateTime Sunrise { get; set; }

        [JsonProperty("ob_time")]
        public DateTime Time { get; set; }

        public string CityName { get; set; }

        public string CountryCode { get; set; }

        [JsonProperty("wind_spd")]
        public string WindSpeed { get; set; }

        [JsonProperty("temp")]
        public float Temperature { get; set; }
    }
}
