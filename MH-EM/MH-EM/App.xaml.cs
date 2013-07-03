using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using MH_EM.View;
using MH_EM.Models;
using MH_EM.src;

namespace MH_EM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int MINIMUM_SPLASH_TIME = 1400; // in Miliseconds
        private const int SPLASH_FADE_TIME = 600;     // in Miliseconds

        public static List<ArmorPart> heads = new List<ArmorPart>();
        public static List<ArmorPart> chests = new List<ArmorPart>();
        public static List<ArmorPart> arms = new List<ArmorPart>();
        public static List<ArmorPart> waists = new List<ArmorPart>();
        public static List<ArmorPart> legs = new List<ArmorPart>();


        protected override void OnStartup(StartupEventArgs e) {
            ////base.OnStartup(e);

            //// Step 1 - Load the splash screen
            //SplashScreen splash = new SplashScreen("src/Images/mhem_logo.png");
            //splash.Show(false, true);   // param: autoclose, topmost

            //// Step 2 - Start a stop watch
            //Stopwatch timer = new Stopwatch();
            //timer.Start();

            //// Step 3 - Load your windows but don't show it yet
            //base.OnStartup(e);

            XMLParser.ParseArmor("../../src/Data/heads.xml", heads);
            XMLParser.ParseArmor("../../src/Data/chests.xml", chests);
            XMLParser.ParseArmor("../../src/Data/arms.xml", arms);
            XMLParser.ParseArmor("../../src/Data/waists.xml", waists);
            XMLParser.ParseArmor("../../src/Data/legs.xml", legs);
            

            MainWindow main = new MainWindow();

            //// Step 4 - Make sure that the splash screen lasts at least two seconds
            //timer.Stop();
            //int remainingTimeToShowSplash = MINIMUM_SPLASH_TIME - (int)timer.ElapsedMilliseconds;
            //if (remainingTimeToShowSplash > 0) {
            //    Thread.Sleep(remainingTimeToShowSplash);
            //}

            //// Step 5 - show the page
            //splash.Close(TimeSpan.FromMilliseconds(SPLASH_FADE_TIME));
            main.Show();
        }


    }
}
