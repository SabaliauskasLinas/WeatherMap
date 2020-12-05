using Weather.Core.Entities;
using Weather.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Core.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _repository;
        public WeatherService(IWeatherRepository repository)
        {
            _repository = repository;
        }

        public ServerResult<WeatherDetails> GetWeatherDetails(WeatherArgs args)
        {
            return _repository.GetWeather(args);
        }
    }
}
