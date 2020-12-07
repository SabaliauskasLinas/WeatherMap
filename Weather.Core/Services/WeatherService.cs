using Weather.Core.Entities;
using Weather.Core.Repositories;
using System;

namespace Weather.Core.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _repository;
        private string _errorMessage = "Error while trying to fetch data";
        private int _clicksCount;
        private float _temperatureTotal;
        private float _windSpeedTotal;
        public WeatherService(IWeatherRepository repository)
        {
            _repository = repository;
        }

        public ServerResult<WeatherDetails> GetWeatherDetails(WeatherArgs args)
        {
            try
            {
                var result = _repository.GetWeather(args);
                if (result == null)
                    return new ServerResult<WeatherDetails> { Success = false, Message = _errorMessage };

                AddWeatherTotals(result);
                return new ServerResult<WeatherDetails> { Success = true, Data = result };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ServerResult<WeatherDetails>()
                {
                    Success = false,
                    Message = _errorMessage,
                };
            }
        }

        public ServerResult<WeatherAverages> GetWeatherAverages()
        {
            try
            {
                var averages = new WeatherAverages
                {
                    ClicksCount = _clicksCount,
                    Temperature = _temperatureTotal / _clicksCount,
                    WindSpeed = _windSpeedTotal / _clicksCount,
                };

                return new ServerResult<WeatherAverages> { Success = true, Data = averages };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ServerResult<WeatherAverages>()
                {
                    Success = false,
                    Message = _errorMessage,
                };
            }

        }

        public void ResetAverages()
        {
            _clicksCount = 0;
            _temperatureTotal = 0;
            _windSpeedTotal = 0;
        }

        private void AddWeatherTotals(WeatherDetails details)
        {
            _clicksCount++;
            _temperatureTotal += details.Temperature;
            _windSpeedTotal += details.WindSpeed;
        }
    }
}
