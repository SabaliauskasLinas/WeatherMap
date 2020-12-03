using Microsoft.Maps.MapControl.WPF;
using System.Windows;
using System.Windows.Input;
using View.ViewModels;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            myMap.Focus();

            // Assign to the data context so binding can be used.
            base.DataContext = viewModel;
        }

        private void MapWithPushpins_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            Point mousePosition = e.GetPosition(this);
            Location pinLocation = myMap.ViewportPointToLocation(mousePosition);

            Pushpin pin = new Pushpin();
            pin.Location = pinLocation;

            myMap.Children.Add(pin);
        }
    }
}
