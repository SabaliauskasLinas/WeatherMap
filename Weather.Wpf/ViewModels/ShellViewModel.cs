using Caliburn.Micro;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Windows;
using System.Windows.Input;
using Weather.Core.Entities;
using Weather.Core.Services;

namespace Weather.Wpf.ViewModels
{
    public class ShellViewModel : Screen
    {
        private readonly IWeatherService _weatherService;
        private IShellView _view;
        private bool _dataLoaded;
        private double _latitude;
        private double _longitude;
        private string _cityName;
        private string _countryCode;
        private TimeSpan _sunrise;
        private TimeSpan _sunset;
        private float _temperature;
        private float _windSpeed;
        private int _cloudCoverage;
        private string _skyImage;
        private string _skyDescription = "Double click on a map";

        protected override void OnViewAttached(object view, object context)
        {
            _view = view as IShellView;
        }

        public ShellViewModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        #region Bindings

        public bool DataLoaded
        {
            get { return _dataLoaded; }
            set 
            { 
                _dataLoaded = value;
                NotifyOfPropertyChange(nameof(DataLoaded));
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

        #endregion

        public void MyMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var map = sender as Map;
            e.Handled = true;
            Point mousePosition = e.GetPosition(_view.GetInstance());
            Location pinLocation = map.ViewportPointToLocation(mousePosition);

            var args = new WeatherArgs()
            {
                Latitude = pinLocation.Latitude,
                Longitude = pinLocation.Longitude
            };

            var result = _weatherService.GetWeatherDetails(args);
            if (!result.Success)
            {
                SkyDescription = result.Message ?? "Unknown error";
                return;
            }
            else
                DataLoaded = true;


            Latitude = result.Data.Latitude;
            Longitude = result.Data.Longitude;
            CityName = result.Data.CityName;
            CountryCode = result.Data.CountryCode;
            Sunrise = result.Data.Sunrise.TimeOfDay;
            Sunset = result.Data.Sunset.TimeOfDay;
            Temperature = result.Data.Temperature;
            WindSpeed = result.Data.WindSpeed;
            CloudCoverage = result.Data.CloudCoverage;
            SkyImage = result.Data.Description.Icon;
            SkyDescription = result.Data.Description.Text;

            Pushpin pin = new Pushpin
            {
                Location = pinLocation
            };

            map.Children.Clear();
            map.Children.Add(pin);
        }
    }
}
