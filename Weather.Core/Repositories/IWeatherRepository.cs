using Weather.Core.Entities;

namespace Weather.Core.Repositories
{
    public interface IWeatherRepository
    {
        ServerResult<WeatherDetails> GetWeather(WeatherArgs args);
    }
}