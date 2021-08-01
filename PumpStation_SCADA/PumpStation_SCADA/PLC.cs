using S7.Net; //Add thư viện, nhớ phải add luôn reference
using System;

namespace MySCADA
{
    // Đang copy file bên S7 Communication sang PLC của MySCADA.sln
    public class PLC
    {
        private string IPAddress = "192.168.1.201";
        private System.Timers.Timer ReadPLCTimer = new System.Timers.Timer();
        private Plc thePLC;
        public Device PumpStation_1 = new Device(); 
        public Device PumpStation_2 = new Device(); 
        public Device PumpStation_3 = new Device(); 
        public SCADA Parent;
        public float pressure1, pressure2, pressure3;

        public PLC()
        {
            thePLC = new Plc(CpuType.S71500, IPAddress, 0, 1);
            try
            {
                thePLC.Open();
            }
            catch
            {
                ;
            }
            //Tick là Timer của Form not Console
            ReadPLCTimer.Interval = 1000;
            ReadPLCTimer.Enabled = true;
            ReadPLCTimer.Elapsed += new System.Timers.ElapsedEventHandler(ReadPLCTimer_Tick);
            ReadPLCTimer.Start();
        }

        private void ReadPLCTimer_Tick(object sender, EventArgs e)
        {
            if (thePLC.IsConnected)
            {
                thePLC.ReadClass(PumpStation_1, 1);
                thePLC.ReadClass(PumpStation_2, 2);
                thePLC.ReadClass(PumpStation_3, 3);

                pressure1 = PumpStation_1.Pressure;
                pressure2 = PumpStation_2.Pressure;
                pressure3 = PumpStation_3.Pressure;

                Historian pressureHistorian1 = Parent.FindHistorian("pressureHistorian_1");
                Historian pressureHistorian2 = Parent.FindHistorian("pressureHistorian_2");
                Historian pressureHistorian3 = Parent.FindHistorian("pressureHistorian_3");

                pressureHistorian1.ringBuffer.Enqueue(pressure1);
                pressureHistorian2.ringBuffer.Enqueue(pressure2);
                pressureHistorian3.ringBuffer.Enqueue(pressure3);

                Historian pressureTimestampHistorian1 = Parent.FindHistorian("pressureTimestampHistorian_1");
                Historian pressureTimestampHistorian2 = Parent.FindHistorian("pressureTimestampHistorian_2");
                Historian pressureTimestampHistorian3 = Parent.FindHistorian("pressureTimestampHistorian_3");

                pressureTimestampHistorian1.ringBuffer.Enqueue(DateTime.Now);
                pressureTimestampHistorian2.ringBuffer.Enqueue(DateTime.Now);
                pressureTimestampHistorian3.ringBuffer.Enqueue(DateTime.Now);

                //Alarm levelAlarm = Parent.FindAlarm("Level");
                //AlarmTag levelAlarmTag = new AlarmTag("Level", DateTime.Now, Level, " "); //Chưa so sánh nên chưa biết alarm code
                //levelAlarm.CheckAlarmLevel(levelAlarmTag);
            }
        }

        public void WriteBool(string address, bool value)
        {
            thePLC.Write(address, value);
        }

        public void WriteInt(string address, short value)
        {
            thePLC.Write(address, value);
        }

        public void WriteIntAsync(string address, short value)
        {
            int startByteAdd = Convert.ToInt32(address[7]);
            thePLC.WriteAsync(DataType.DataBlock, startByteAdd, 0, value);
        }
    }

    public class Device
    {
        public bool Mode { get; set; }
        public bool Start1 { get; set; }
        public bool Stop1 { get; set; }
        public bool Start2 { get; set; }
        public bool Stop2 { get; set; }
        public bool Start { get; set; }
        public bool Stop { get; set; }
        public float Pressure { get; set; }
        public bool Running1 { get; set; }
        public bool Running2 { get; set; }
    }
}