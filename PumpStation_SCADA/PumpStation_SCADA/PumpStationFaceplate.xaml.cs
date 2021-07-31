using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PumpStation_SCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PumpStationFaceplate : TabbedPage
    {
        private int _index;
        public PumpStationFaceplate(int index)
        {
            InitializeComponent();
            _index = index;
            stationTitle.Text = $"PUMP STATION {index}";
        }
    }
}