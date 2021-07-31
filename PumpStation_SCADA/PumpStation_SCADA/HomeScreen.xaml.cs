using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace PumpStation_SCADA.Views
{
    public partial class HomeScreen : ContentPage
    {


        Pin pinPumpStation1 = new Pin()
        {
            Type = PinType.Place,
            Label = "Pump Station 1",
            Position = new Position(10.766024390958751, 106.64286302830324),
            Tag = "1",
        };
        Pin pinPumpStation2 = new Pin()
        {
            Type = PinType.Place,
            Label = "Pump Station 2",
            Position = new Position(11.067191866480413, 106.6419228446841),
            Tag = "2",
        };
        public HomeScreen()
        {
            InitializeComponent();
                map.Pins.Add(pinPumpStation1);
                map.Pins.Add(pinPumpStation2);
                map.SelectedPinChanged += Map_SelectedPinChanged;
                map.MoveToRegion(MapSpan.FromCenterAndRadius(pinPumpStation1.Position, Distance.FromMeters(10000)));
        }
        private void Map_SelectedPinChanged(object sender, SelectedPinChangedEventArgs e)
        {
            if (e.SelectedPin != null)
            {
                Pin selectedPin = e.SelectedPin;
                if (selectedPin.Label == "Pump Station 1")
                {
                    Navigation.PushAsync(App.pumpStation_1);
                }
                else if (selectedPin.Label == "Pump Station 2")
                {
                    Navigation.PushAsync(App.pumpStation_2);
                }
            }
        }
    }
}