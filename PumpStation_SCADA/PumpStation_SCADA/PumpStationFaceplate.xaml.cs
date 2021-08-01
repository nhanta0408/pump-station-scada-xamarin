using MySCADA;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PumpStation_SCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PumpStationFaceplate : Xamarin.Forms.TabbedPage
    {
        private int _index;
        public SCADA Parent;
        private bool pausedReadMode;

        public PumpStationFaceplate(int index)
        {
            InitializeComponent();
            _index = index;
            myTabbedPage.Title = $"PUMP STATION {index}";
            stationTitle.Text = $"PUMP STATION {index}";
            modePicker.Items.Add("Auto");
            modePicker.Items.Add("Manual");
            pausedReadMode = false;

            Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                MySCADA.Task task = App.Root.FindTask("Task_1");
                if (task != null)
                {
                    Tag tagMode, tagPressure, tagRunning1, tagRunning2;
                    tagMode = task.FindTag($"PumpStation_{_index}_Mode");
                    tagPressure = task.FindTag($"PumpStation_{_index}_Pressure");
                    tagRunning1 = task.FindTag($"PumpStation_{_index}_Running1");
                    tagRunning2 = task.FindTag($"PumpStation_{_index}_Running2");

                    if (tagMode != null)
                    {
                        bool autoManual = tagMode.Value;
                        int selectedIndex = autoManual ? 1 : 0;
                        if (modePicker.SelectedIndex == selectedIndex)
                        {
                            pausedReadMode = false;
                        }
                        if (modePicker.IsFocused == false && !pausedReadMode)
                        {
                            modePicker.SelectedIndex = autoManual ? 1 : 0;
                        }
                    }

                    if (tagPressure != null)
                    {
                        float _pressure = tagPressure.Value;
                        pressureText.Text = _pressure.ToString();
                    }
                    if (tagRunning1 != null)
                    {
                        bool _running = tagRunning1.Value;
                        running1Ellipse.Fill = _running ? Brush.Green : Brush.Gray;
                    }
                    if (tagRunning2 != null)
                    {
                        bool _running = tagRunning2.Value;
                        running2Ellipse.Fill = _running ? Brush.Green : Brush.Gray;
                    }
                }

                return true;
            });
        }

        private void modePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            pausedReadMode = true;
            if (modePicker.SelectedIndex == 0)
            {
                Parent.S71500.WriteBool($"DB{_index}.DBX0.0", false);
            }
            else
            {
                Parent.S71500.WriteBool($"DB{_index}.DBX0.0", true);
            }
        }

        private void start1Btn_Pressed(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{_index}.DBX0.1", true);
        }

        private void start1Btn_Released(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{_index}.DBX0.1", false);
        }

        private void stop1Btn_Pressed(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{_index}.DBX0.2", true);
        }

        private void stop1Btn_Released(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{_index}.DBX0.2", false);
        }

        private void start2Btn_Pressed(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{_index}.DBX0.3", true);
        }

        private void start2Btn_Released(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{_index}.DBX0.3", false);
        }

        private void stop2Btn_Pressed(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{_index}.DBX0.4", true);
        }

        private void stop2Btn_Released(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{_index}.DBX0.4", false);
        }
    }
}