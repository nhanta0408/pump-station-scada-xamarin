using System;
using System.Collections;

namespace MySCADA
{
    public class Task
    {
        public SCADA Parent = null;
        public string Name;
        private int Period; //Private, gán 1 giá trị fixed luôn, không cho can thiệp từ bên ngoài
        private System.Timers.Timer UpdateTimer = null;
        public ArrayList Tags = new ArrayList();

        public Task(string name, int period)
        {
            Name = name;
            Period = period;
        }

        public void AddTag(Tag tag)     //Hàm add phần tử, sẵn tiện trỏ luôn chính nó làm parent
        {
            tag.Parent = this;
            Tags.Add(tag);
        }

        public Tag FindTag(string name)
        {
            Tag tag = null;
            for (int i = 0; i < Tags.Count; i++)
            {
                tag = (Tag)Tags[i];     //ép kiểu
                if (tag.Name == name)    //Nếu tag có tên trùng với tên cần tìm
                    return tag;
            }
            return null;
        }

        public void Engine()        //Tạo Timer và update cho cái Timer đó
        {
            UpdateTimer = new System.Timers.Timer(Period);
            UpdateTimer.AutoReset = true;
            UpdateTimer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateTags);
            UpdateTimer.Start();
        }

        private void UpdateTags(object sender, System.Timers.ElapsedEventArgs e)
        {
            for (int i = 0; i < Tags.Count; i++)
            {
                Tag tag = (Tag)Tags[i];

                string[] temp_result_slit = tag.Address.Split('.');
                string obj = temp_result_slit[0];
                string signal = temp_result_slit[1];
                switch (obj)
                {
                    case "PumpStation_1":
                        switch (signal)
                        {
                            case "Mode":
                                tag.Value = Parent.S71500.PumpStation_1.Mode; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;

                            case "Start1":
                                tag.Value = Parent.S71500.PumpStation_1.Start1; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop1":
                                tag.Value = Parent.S71500.PumpStation_1.Stop1; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Start2":
                                tag.Value = Parent.S71500.PumpStation_1.Start2; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop2":
                                tag.Value = Parent.S71500.PumpStation_1.Stop2; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Start":
                                tag.Value = Parent.S71500.PumpStation_1.Start; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop":
                                tag.Value = Parent.S71500.PumpStation_1.Stop; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;

                            case "Pressure":
                                tag.Value = Parent.S71500.PumpStation_1.Pressure; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;

                            case "Running1":
                                tag.Value = Parent.S71500.PumpStation_1.Running1; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Running2":
                                tag.Value = Parent.S71500.PumpStation_1.Running2; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                        }
                        break;
                    case "PumpStation_2":
                        switch (signal)
                        {
                            case "Mode":
                                tag.Value = Parent.S71500.PumpStation_2.Mode; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;

                            case "Start1":
                                tag.Value = Parent.S71500.PumpStation_2.Start1; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop1":
                                tag.Value = Parent.S71500.PumpStation_2.Stop1; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Start2":
                                tag.Value = Parent.S71500.PumpStation_2.Start2; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop2":
                                tag.Value = Parent.S71500.PumpStation_2.Stop2; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Start":
                                tag.Value = Parent.S71500.PumpStation_2.Start; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop":
                                tag.Value = Parent.S71500.PumpStation_2.Stop; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;

                            case "Pressure":
                                tag.Value = Parent.S71500.PumpStation_2.Pressure; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;

                            case "Running1":
                                tag.Value = Parent.S71500.PumpStation_2.Running1; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Running2":
                                tag.Value = Parent.S71500.PumpStation_2.Running2; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                        }
                        break;
                    case "PumpStation_3":
                        switch (signal)
                        {
                            case "Mode":
                                tag.Value = Parent.S71500.PumpStation_3.Mode; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;

                            case "Start1":
                                tag.Value = Parent.S71500.PumpStation_3.Start1; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop1":
                                tag.Value = Parent.S71500.PumpStation_3.Stop1; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Start2":
                                tag.Value = Parent.S71500.PumpStation_3.Start2; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop2":
                                tag.Value = Parent.S71500.PumpStation_3.Stop2; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Start":
                                tag.Value = Parent.S71500.PumpStation_3.Start; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Stop":
                                tag.Value = Parent.S71500.PumpStation_3.Stop; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;

                            case "Pressure":
                                tag.Value = Parent.S71500.PumpStation_3.Pressure; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;

                            case "Running1":
                                tag.Value = Parent.S71500.PumpStation_3.Running1; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                            case "Running2":
                                tag.Value = Parent.S71500.PumpStation_3.Running2; //Parent là SCADA
                                tag.Quality = "Good";
                                tag.TimeStamp = DateTime.Now;
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void Sleep()
        {
            if (UpdateTimer != null)
            {
                UpdateTimer.Stop();
            }
        }

        public void Resume()
        {
            if (UpdateTimer != null)
            {
                UpdateTimer.Start();
            }
        }

        public void Kill()
        {
            if (UpdateTimer != null)
            {
                UpdateTimer.Dispose();
                UpdateTimer = null;     //Nhớ dispose xong thì gán nó lại bằng null
            }
        }
    }
}