using MySCADA;
using System;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace PumpStation_SCADA.Views
{
    public partial class HomeScreen : ContentPage
    {
        public SCADA Parent;
        private Pin pinPumpStation1 = new Pin()
        {
            Type = PinType.Place,
            Label = "Pump Station 1",
            Position = new Position(10.766024390958751, 106.64286302830324),
            Tag = "1",
        };

        private Pin pinPumpStation2 = new Pin()
        {
            Type = PinType.Place,
            Label = "Pump Station 2",
            Position = new Position(10.867191866480413, 106.6419228446841),
            Tag = "2",
        };

        private Pin pinPumpStation3 = new Pin()
        {
            Type = PinType.Place,
            Label = "Pump Station 3",
            Address = "Address 3 nè",
            Position = new Position(10.800191866480413, 106.5419228446841),
            Tag = "3",
        };

        public HomeScreen()
        {
            InitializeComponent();
            map.Pins.Add(pinPumpStation1);
            map.Pins.Add(pinPumpStation2);
            map.Pins.Add(pinPumpStation3);
            map.InfoWindowClicked += Map_InfoWindowClicked;
            map.SelectedPinChanged += Map_SelectedPinChanged;
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pinPumpStation1.Position, Distance.FromMeters(20000)));
            Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                pinPumpStation1.Address = App.Root.S71500.PumpStation_1.Pressure.ToString() + " bar(s)";
                pinPumpStation2.Address = App.Root.S71500.PumpStation_2.Pressure.ToString() + " bar(s)";
                pinPumpStation3.Address = App.Root.S71500.PumpStation_3.Pressure.ToString() + " bar(s)";

                return true; });
        }

        private void Map_InfoWindowClicked(object sender, InfoWindowClickedEventArgs e)
        {
            System.Console.WriteLine($"Clicked Window Info {e.Pin.Label}");
            if (e.Pin.Label == "Pump Station 1")
            {
                Navigation.PushAsync(App.Root.PumpStationFaceplates[0]);
            }
            else if (e.Pin.Label == "Pump Station 2")
            {
                Navigation.PushAsync(App.Root.PumpStationFaceplates[1]);
            }
            else if (e.Pin.Label == "Pump Station 3")
            {
                Navigation.PushAsync(App.Root.PumpStationFaceplates[2]);
            }
        }

        private void Map_SelectedPinChanged(object sender, SelectedPinChangedEventArgs e)
        {
            if (e.SelectedPin != null)
            {
                //Pin selectedPin = e.SelectedPin;
                //if (selectedPin.Label == "Pump Station 1")
                //{
                //    Navigation.PushAsync(App.Root.PumpStationFaceplates[0]);
                //}
                //else if (selectedPin.Label == "Pump Station 2")
                //{
                //    Navigation.PushAsync(App.Root.PumpStationFaceplates[1]);
                //}
                //else if (selectedPin.Label == "Pump Station 3")
                //{
                //    Navigation.PushAsync(App.Root.PumpStationFaceplates[2]);
                //}
            }
        }
    }
}