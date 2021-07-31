using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace PumpStation_SCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PumpStationFaceplate : Xamarin.Forms.TabbedPage
    {
        private int _index;
        public PumpStationFaceplate(int index)
        {
            InitializeComponent();
            _index = index;
            myTabbedPage.Title = $"PUMP STATION {index}";
            stationTitle.Text = $"PUMP STATION {index}";

        }
    }
}