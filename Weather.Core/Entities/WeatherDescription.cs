using Newtonsoft.Json;

namespace Weather.Core.Entities
{
    public class WeatherDescription
    {
        public string Icon { get; set; }

        [JsonProperty("description")]
        public string Text { get; set; }
    }
}
