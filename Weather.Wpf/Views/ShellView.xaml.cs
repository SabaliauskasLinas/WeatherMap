using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Weather.Wpf.ViewModels;

namespace Weather.Wpf.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : IShellView
    {
        public ShellView()
        {
            InitializeComponent();
        }

        public ShellView GetInstance()
        {
            return this;
        }

        private void MyMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            Point mousePosition = e.GetPosition(this);
            Location pinLocation = MyMap.ViewportPointToLocation(mousePosition);
            Pushpin pin = new Pushpin
            {
                Location = pinLocation
            };

            MyMap.Children.Add(pin);
        }
    }
}
