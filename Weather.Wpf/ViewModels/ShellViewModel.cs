using Caliburn.Micro;
using Microsoft.Maps.MapControl.WPF;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Weather.Wpf.Models;

namespace Weather.Wpf.ViewModels
{
    public class ShellViewModel : Screen
    {
        private readonly IWeatherService _weatherService;
        private float _temperature = 15.6f;
        private string _lastName;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;
        private IShellView _view;

        protected override void OnViewAttached(object view, object context)
        {
            _view = view as IShellView;
        }


        public ShellViewModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public float Temperature
        {
            get
            { return _temperature; }
            set
            {
                _temperature = value;
            }
        }

        public void MyMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var map = sender as Map;
            e.Handled = true;
            Point mousePosition = e.GetPosition(_view.GetInstance());
            Location pinLocation = map.ViewportPointToLocation(mousePosition);

            var result = _weatherService.GetWeatherDetails(new Model.Entities.WeatherArgs() { Latitude = pinLocation.Latitude, Longitude = pinLocation.Longitude });

            Pushpin pin = new Pushpin
            {
                Location = pinLocation
            };
            map.Children.Clear();
            map.Children.Add(pin);
        }
    }
}
