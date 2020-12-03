using Model.Entities;

namespace Model.Services
{
    public interface IWeatherService
    {
        ServerResult<WeatherDetails> GetWeatherDetails(WeatherArgs args);
    }
}