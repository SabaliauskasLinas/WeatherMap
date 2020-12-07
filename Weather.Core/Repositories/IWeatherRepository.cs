using Weather.Core.Entities;

namespace Weather.Core.Repositories
{
    public interface IWeatherRepository
    {
        WeatherDetails GetWeather(WeatherArgs args);
    }
}