using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MySCADA
{
    public class Alarm
    {
        public SCADA Parent = null;
        public string Name;
        public List<AlarmTag> alarmTags = new List<AlarmTag>();
        public const int  low = 2, high = 8;
         Color Color1 = Color.Red;
        Color Color2 = Color.Orange;
        Color Color3 = Color.Black;



        public Alarm(string name)
        {
            Name = name;
        }
        public void CheckAlarmLevel(AlarmTag alarmTag)
        {
            
           
                if (alarmTag.Value >= high)
                {
                    alarmTag.AlarmCode = "H";
                    alarmTag.Detail = "Áp suất đang là High";
                    AddAlarmTag(alarmTag);
                    alarmTag.Color = Color1;

                }
                else if (alarmTag.Value >= low && alarmTag.Value < high)
                {

                    alarmTag.AlarmCode = "N";
                    alarmTag.Detail = "Áp suất đang là Normal";
                    AddAlarmTag(alarmTag);
                    alarmTag.Color = Color3;
                }

                else if (alarmTag.Value >= 0 && alarmTag.Value < low)
                {

                    alarmTag.AlarmCode = "L";
                    alarmTag.Detail = "Áp suất đang là Low";
                    AddAlarmTag(alarmTag);
                    alarmTag.Color = Color1;
                }
            

        }
        public void AddAlarmTag(AlarmTag alarmTag)
        {
            AlarmTag lastAlarm = alarmTags.LastOrDefault();
            if (lastAlarm != null)
            {
                if (alarmTag.AlarmCode != lastAlarm.AlarmCode)
                {
                    alarmTags.Add(alarmTag);
                }
            }
            else
            {
                alarmTags.Add(alarmTag);
            }


        }
    }
}
