using Microcharts;
using MySCADA;
using SkiaSharp;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.ChartEntry;

namespace PumpStation_SCADA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PumpStationFaceplate : Xamarin.Forms.TabbedPage
    {
        private int _index;
        public SCADA Parent;
        private bool pausedReadMode;
        private List<Entry> entries = new List<Entry>
        {

        };
        public PumpStationFaceplate(int index)
        {
            InitializeComponent();
            _index = index;
            myTabbedPage.Title = $"PUMP STATION {index}";
            stationTitle.Text = $"PUMP STATION {index}";
            modePicker.Items.Add("Auto");
            modePicker.Items.Add("Manual");
            pausedReadMode = false;

            pressureTrend.Chart = new LineChart
            {
                Entries = entries,
                LineMode = LineMode.Straight,
                MaxValue = 10,
                MinValue = 0,
                LabelTextSize = 45,
                LabelOrientation = Orientation.Vertical,
                ValueLabelOrientation = Orientation.Vertical,
                PointMode = PointMode.Circle,
            };

            pressureTrend.Chart.IsAnimated = false;
            int _preRear = 0;
            Historian pressureHistorian = App.Root.FindHistorian($"pressureHistorian_{_index}");
            Historian pressureTimestampHistorian = App.Root.FindHistorian($"pressureTimestampHistorian_{_index}");
            bool firstScan = true;
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
                        startBtn.BackgroundColor = autoManual ? Color.Gray : Color.DarkGreen;
                        stopBtn.BackgroundColor = autoManual ? Color.Gray : Color.DarkRed;
                        start1Btn.BackgroundColor = autoManual ? Color.DarkGreen : Color.Gray;
                        stop1Btn.BackgroundColor = autoManual ? Color.DarkRed : Color.Gray;
                        start2Btn.BackgroundColor = autoManual ? Color.DarkGreen : Color.Gray;
                        stop2Btn.BackgroundColor = autoManual ? Color.DarkRed : Color.Gray;

                        startBtn.IsEnabled = !autoManual;
                        stopBtn.IsEnabled = !autoManual;
                        start1Btn.IsEnabled = autoManual;
                        stop1Btn.IsEnabled = autoManual;
                        start2Btn.IsEnabled = autoManual;
                        stop2Btn.IsEnabled = autoManual;
                    }

                    if (tagPressure != null)
                    {
                        float _pressure = tagPressure.Value;
                        pressureText.Text = _pressure.ToString() + " bar";

                        if (_preRear != pressureHistorian.ringBuffer.rear)
                        {
                            float currentPressure = pressureHistorian.ringBuffer.Peek();
                            DateTime currentTimestamp = pressureTimestampHistorian.ringBuffer.Peek();
                            if (entries.Count > 40)
                            {
                                entries.RemoveAt(0);
                            }
                            if (pressureHistorian.ringBuffer.rear % 10 == 0 || firstScan)
                            {
                                entries.Add(new Entry(currentPressure)
                                {
                                    Label = currentTimestamp.ToString("HH:mm:ss"),
                                    ValueLabel = currentPressure.ToString(),
                                    Color = SKColor.Parse("#0033cc"),
                                    TextColor = SKColor.Parse("#000000"),
                                });
                            }
                            else
                            {
                                entries.Add(new Entry(currentPressure)
                                {
                                    TextColor = SKColor.Parse("#000000"),
                                });
                            }

                            pressureTrend.Chart.Entries = entries;
                            _preRear = pressureHistorian.ringBuffer.rear;
                        }
                        firstScan = false;

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
            bool autoManual;
            pausedReadMode = true;
            if (modePicker.SelectedIndex == 0)
            {
                autoManual = false;
                Parent.S71500.WriteBool($"DB{_index}.DBX0.0", false);
            }
            else
            {
                autoManual = true;
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

        private void startBtn_Pressed(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{_index}.DBX0.5", true);
        }

        private void startBtn_Released(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{_index}.DBX0.5", false);
        }

        private void stopBtn_Pressed(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{_index}.DBX0.6", true);

        }

        private void stopBtn_Released(object sender, EventArgs e)
        {
            Parent.S71500.WriteBool($"DB{_index}.DBX0.6", false);

        }
    }
}