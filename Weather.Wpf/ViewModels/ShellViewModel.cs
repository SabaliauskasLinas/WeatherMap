using Caliburn.Micro;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Weather.Core.Entities;
using Weather.Core.Services;

namespace Weather.Wpf.ViewModels
{
    public class ShellViewModel : Screen
    {
        private readonly IWeatherService _weatherService;
        private IShellView _view;
        private Map _map;
        private Pushpin _lastPin;
        private bool _detailsLoaded;
        private bool _averagesLoaded;
        private double _latitude;
        private double _longitude;
        private string _cityName;
        private string _countryCode;
        private TimeSpan _sunrise;
        private TimeSpan _sunset;
        private float _temperature;
        private float _temperatureAverage;
        private float _windSpeed;
        private float _windSpeedAverage;
        private int _cloudCoverage;
        private string _skyImage;
        private string _skyDescription = "Double click on a map";
        private string _averagesText;
        private int _clicksCount = 0;

        #region Initialization
        protected override void OnViewAttached(object view, object context)
        {
            _view = view as IShellView;
        }

        public ShellViewModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        #endregion

        #region Bindings

        public bool DetailsLoaded
        {
            get { return _detailsLoaded; }
            set 
            { 
                _detailsLoaded = value;
                NotifyOfPropertyChange(nameof(DetailsLoaded));
            }
        }

        public bool AveragesLoaded
        {
            get { return _averagesLoaded; }
            set
            {
                _averagesLoaded = value;
                NotifyOfPropertyChange(nameof(AveragesLoaded));
            }
        }

        public string SkyImage
        {
            get { return _skyImage; }
            set
            {
                _skyImage = $@"..\Resources\{value}.png";
                NotifyOfPropertyChange(nameof(SkyImage));
            }
        }

        public string SkyDescription
        {
            get { return _skyDescription; }
            set
            {
                _skyDescription = value;
                NotifyOfPropertyChange(nameof(SkyDescription));
            }
        }

        public string AveragesText
        {
            get { return _averagesText; }
            set
            {
                _averagesText = value;
                NotifyOfPropertyChange(nameof(AveragesText));
            }
        }

        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                NotifyOfPropertyChange(nameof(Latitude));
            }
        }

        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                NotifyOfPropertyChange(nameof(Longitude));
            }
        }

        public string CityName
        {
            get { return _cityName; }
            set
            {
                _cityName = value;
                NotifyOfPropertyChange(nameof(CityName));
            }
        }

        public string CountryCode
        {
            get { return _countryCode; }
            set
            {
                _countryCode = value;
                NotifyOfPropertyChange(nameof(CountryCode));
            }
        }

        public TimeSpan Sunrise
        {
            get { return _sunrise; }
            set
            {
                _sunrise = value;
                NotifyOfPropertyChange(nameof(Sunrise));
            }
        }

        public TimeSpan Sunset
        {
            get { return _sunset; }
            set
            {
                _sunset = value;
                NotifyOfPropertyChange(nameof(Sunset));
            }
        }

        public float Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                NotifyOfPropertyChange(nameof(Temperature));
            }
        }

        public float WindSpeed
        {
            get { return _windSpeed; }
            set
            {
                _windSpeed = value;
                NotifyOfPropertyChange(nameof(WindSpeed));
            }
        }

        public int CloudCoverage
        {
            get { return _cloudCoverage; }
            set
            {
                _cloudCoverage = value;
                NotifyOfPropertyChange(nameof(CloudCoverage));
            }
        }

        public int ClicksCount
        {
            get { return _clicksCount; }
            set 
            { 
                _clicksCount = value;
                NotifyOfPropertyChange(nameof(ClicksCount));
            }
        }

        public float TemperatureAverage
        {
            get { return _temperatureAverage; }
            set
            {
                _temperatureAverage = value;
                NotifyOfPropertyChange(nameof(TemperatureAverage));
            }
        }

        public float WindSpeedAverage
        {
            get { return _windSpeedAverage; }
            set
            {
                _windSpeedAverage = value;
                NotifyOfPropertyChange(nameof(WindSpeedAverage));
            }
        }

        public void ResetAverages()
        {
            _weatherService.ResetAverages();
            AveragesLoaded = false;
            _map.Children.Clear();
        }

        #endregion

        #region Event Handlers
        public void MyMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            var map = sender as Map;
            if (_map == null)
                _map = map;

            Point mousePosition = e.GetPosition(_view.GetInstance());
            Location location = map.ViewportPointToLocation(mousePosition);
            FillWeatherDetails(location);
            FillWeatherAverages();
            AddPushPin(location);
        }
        #endregion

        #region Helper Methods
        private void FillWeatherDetails(Location location)
        {

            var args = new WeatherArgs()
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude
            };

            var response = _weatherService.GetWeatherDetails(args);
            if (!response.Success)
                SkyDescription = response.Message ?? "Unknown error";
            else
            {
                Latitude = response.Data.Latitude;
                Longitude = response.Data.Longitude;
                CityName = response.Data.CityName;
                CountryCode = response.Data.CountryCode;
                Sunrise = response.Data.Sunrise.TimeOfDay;
                Sunset = response.Data.Sunset.TimeOfDay;
                Temperature = response.Data.Temperature;
                WindSpeed = response.Data.WindSpeed;
                CloudCoverage = response.Data.CloudCoverage;
                SkyImage = response.Data.Description.Icon;
                SkyDescription = response.Data.Description.Text;
                DetailsLoaded = true;
            }
        }
        
        private void FillWeatherAverages()
        {
            var response = _weatherService.GetWeatherAverages();
            if (!response.Success)
                AveragesText = response.Message ?? "Unknown error";
            else if (response.Data.ClicksCount > 1)
            {
                AveragesText = $"Average from {response.Data.ClicksCount} clicks";
                TemperatureAverage = response.Data.Temperature;
                WindSpeedAverage = response.Data.WindSpeed;
                AveragesLoaded = true;
            }
        }

        private void AddPushPin(Location location)
        {
            var pin = new Pushpin
            {
                Location = location,
                Background = Brushes.Red,
            };

            if (_lastPin != null)
                _lastPin.Background = Brushes.Gray;

            _lastPin = pin;
            _map.Children.Add(pin);
        }
        #endregion
    }
}
