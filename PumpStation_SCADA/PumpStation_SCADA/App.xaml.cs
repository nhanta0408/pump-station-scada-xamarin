﻿using MySCADA;
using PumpStation_SCADA.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PumpStation_SCADA
{
    public partial class App : Application
    {
        public static SCADA Root;
        public static PumpStationFaceplate pumpStation_1 = new PumpStationFaceplate(1);
        public static PumpStationFaceplate pumpStation_2 = new PumpStationFaceplate(2);
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
             
            //Root = new SCADA();
            //PLC plc = new PLC();
            //Root.AddPLC(plc); 
            //Task Task1 = new Task("Task_1", 100);
            ////Tạo các Tag
            //#region TagDeclaration

            //Tag PumpStation_1_Mode = new Tag("PumpStation_1_Mode", "PumpStation_1.Mode");
            //Tag PumpStation_2_Mode = new Tag("PumpStation_2_Mode", "PumpStation_2.Mode");
            //Tag PumpStation_3_Mode = new Tag("PumpStation_3_Mode", "PumpStation_3.Mode");

            //Tag PumpStation_1_Start1 = new Tag("PumpStation_1_Start1", "PumpStation_1.Start1");
            //Tag PumpStation_2_Start1 = new Tag("PumpStation_2_Start1", "PumpStation_2.Start1");
            //Tag PumpStation_3_Start1 = new Tag("PumpStation_3_Start1", "PumpStation_3.Start1");

            //Tag PumpStation_1_Stop1 = new Tag("PumpStation_1_Stop1", "PumpStation_1.Stop1");
            //Tag PumpStation_2_Stop1 = new Tag("PumpStation_2_Stop1", "PumpStation_2.Stop1");
            //Tag PumpStation_3_Stop1 = new Tag("PumpStation_3_Stop1", "PumpStation_3.Stop1");

            //Tag PumpStation_1_Start2 = new Tag("PumpStation_1_Start2", "PumpStation_1.Start2");
            //Tag PumpStation_2_Start2 = new Tag("PumpStation_2_Start2", "PumpStation_2.Start2");
            //Tag PumpStation_3_Start2 = new Tag("PumpStation_3_Start2", "PumpStation_3.Start2");

            //Tag PumpStation_1_Stop2 = new Tag("PumpStation_1_Stop2", "PumpStation_1.Stop2");
            //Tag PumpStation_2_Stop2 = new Tag("PumpStation_2_Stop2", "PumpStation_2.Stop2");
            //Tag PumpStation_3_Stop2 = new Tag("PumpStation_3_Stop2", "PumpStation_3.Stop2");

            //Tag PumpStation_1_Start = new Tag("PumpStation_1_Start", "PumpStation_1.Start");
            //Tag PumpStation_2_Start = new Tag("PumpStation_2_Start", "PumpStation_2.Start");
            //Tag PumpStation_3_Start = new Tag("PumpStation_3_Start", "PumpStation_3.Start");

            //Tag PumpStation_1_Stop = new Tag("PumpStation_1_Stop", "PumpStation_1.Stop");
            //Tag PumpStation_2_Stop = new Tag("PumpStation_2_Stop", "PumpStation_2.Stop");
            //Tag PumpStation_3_Stop = new Tag("PumpStation_3_Stop", "PumpStation_3.Stop");

            //Tag PumpStation_1_Pressure = new Tag("PumpStation_1_Pressure", "PumpStation_1.Pressure");
            //Tag PumpStation_2_Pressure = new Tag("PumpStation_2_Pressure", "PumpStation_2.Pressure");
            //Tag PumpStation_3_Pressure = new Tag("PumpStation_3_Pressure", "PumpStation_3.Pressure");

            //Tag PumpStation_1_Running1 = new Tag("PumpStation_1_Running1", "PumpStation_1.Running1");
            //Tag PumpStation_2_Running1 = new Tag("PumpStation_2_Running1", "PumpStation_2.Running1");
            //Tag PumpStation_3_Running1 = new Tag("PumpStation_3_Running1", "PumpStation_3.Running1");

            //Tag PumpStation_1_Running2 = new Tag("PumpStation_1_Running2", "PumpStation_1.Running2");
            //Tag PumpStation_2_Running2 = new Tag("PumpStation_2_Running2", "PumpStation_2.Running2");
            //Tag PumpStation_3_Running2 = new Tag("PumpStation_3_Running2", "PumpStation_3.Running2");
            //#endregion

            //Root.AddTask(Task1);

            //#region TagIsAddedIntoTheTask
            //Task1.AddTag(PumpStation_1_Mode);
            //Task1.AddTag(PumpStation_2_Mode);
            //Task1.AddTag(PumpStation_3_Mode);

            //Task1.AddTag(PumpStation_1_Start1);
            //Task1.AddTag(PumpStation_2_Start1);
            //Task1.AddTag(PumpStation_3_Start1);

            //Task1.AddTag(PumpStation_1_Stop1);
            //Task1.AddTag(PumpStation_2_Stop1);
            //Task1.AddTag(PumpStation_3_Stop1);

            //Task1.AddTag(PumpStation_1_Start2);
            //Task1.AddTag(PumpStation_2_Start2);
            //Task1.AddTag(PumpStation_3_Start2);

            //Task1.AddTag(PumpStation_1_Stop2);
            //Task1.AddTag(PumpStation_2_Stop2);
            //Task1.AddTag(PumpStation_3_Stop2);

            //Task1.AddTag(PumpStation_1_Start);
            //Task1.AddTag(PumpStation_2_Start);
            //Task1.AddTag(PumpStation_3_Start);

            //Task1.AddTag(PumpStation_1_Stop);
            //Task1.AddTag(PumpStation_2_Stop);
            //Task1.AddTag(PumpStation_3_Stop);

            //Task1.AddTag(PumpStation_1_Pressure);
            //Task1.AddTag(PumpStation_2_Pressure);
            //Task1.AddTag(PumpStation_3_Pressure);

            //Task1.AddTag(PumpStation_1_Running1);
            //Task1.AddTag(PumpStation_2_Running1);
            //Task1.AddTag(PumpStation_3_Running1);

            //Task1.AddTag(PumpStation_1_Running2);
            //Task1.AddTag(PumpStation_2_Running2);
            //Task1.AddTag(PumpStation_3_Running2);
            //#endregion
            //Root.RunTask("Task_1");

            //mainScreen = new MainScreen();
            //MotorFaceplate motorFaceplate1 = new MotorFaceplate(1);
            //MotorFaceplate motorFaceplate2 = new MotorFaceplate(2);
            //MotorFaceplate motorFaceplate3 = new MotorFaceplate(3);
            //Root.AddFaceplate(motorFaceplate1);
            //Root.AddFaceplate(motorFaceplate2);
            //Root.AddFaceplate(motorFaceplate3);

            //Historian levelHistorian = new Historian("Level", 50);
            //Root.AddHistorian(levelHistorian);
            //Historian levelTimestampHistorian = new Historian("LevelTimestamp", 8000);
            //Root.AddHistorian(levelTimestampHistorian);

            //Alarm levelAlarm = new Alarm("Level");
            //Root.AddAlarm(levelAlarm);

            //MainPage = new NavigationPage(new MainScreen());
            MainPage = new AppShell();


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
