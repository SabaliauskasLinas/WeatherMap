using Weather.Core.Entities;

namespace Weather.Core.Services
{
    public interface IWeatherService
    {
        ServerResult<WeatherDetails> GetWeatherDetails(WeatherArgs args);
        ServerResult<WeatherAverages> GetWeatherAverages();
        void ResetAverages();
    }
}