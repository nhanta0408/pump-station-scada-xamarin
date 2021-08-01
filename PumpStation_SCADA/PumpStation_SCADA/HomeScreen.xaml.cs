using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace PumpStation_SCADA.Views
{
    public partial class HomeScreen : ContentPage
    {
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
            Position = new Position(10.800191866480413, 106.5419228446841),
            Tag = "3",
        };

        public HomeScreen()
        {
            InitializeComponent();
            map.Pins.Add(pinPumpStation1);
            map.Pins.Add(pinPumpStation2);
            map.Pins.Add(pinPumpStation3);
            map.SelectedPinChanged += Map_SelectedPinChanged;
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pinPumpStation1.Position, Distance.FromMeters(30000)));
        }

        private void Map_SelectedPinChanged(object sender, SelectedPinChangedEventArgs e)
        {
            if (e.SelectedPin != null)
            {
                Pin selectedPin = e.SelectedPin;
                if (selectedPin.Label == "Pump Station 1")
                {
                    Navigation.PushAsync(App.Root.PumpStationFaceplates[0]);
                }
                else if (selectedPin.Label == "Pump Station 2")
                {
                    Navigation.PushAsync(App.Root.PumpStationFaceplates[1]);
                }
                else if (selectedPin.Label == "Pump Station 3")
                {
                    Navigation.PushAsync(App.Root.PumpStationFaceplates[2]);
                }
            }
        }
    }
}