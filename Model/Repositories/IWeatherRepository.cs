using Model.Entities;

namespace Model.Repositories
{
    public interface IWeatherRepository
    {
        ServerResult<WeatherDetails> GetWeather(WeatherArgs args);
    }
}