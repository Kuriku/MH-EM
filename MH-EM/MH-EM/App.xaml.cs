using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using System.Threading;
using MH_EM.View;

namespace MH_EM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int MINIMUM_SPLASH_TIME = 1400; // in Miliseconds
        private const int SPLASH_FADE_TIME = 600;     // in Miliseconds

        protected override void OnStartup(StartupEventArgs e) {
            ////base.OnStartup(e);

            // Step 1 - Load the splash screen
            SplashScreen splash = new SplashScreen("Images/mhem_logo.png");
            splash.Show(false, true);   // param: autoclose, topmost

            // Step 2 - Start a stop watch
            Stopwatch timer = new Stopwatch();
            timer.Start();

            // Step 3 - Load your windows but don't show it yet
            base.OnStartup(e);
            MainWindow main = new MainWindow();

            // Step 4 - Make sure that the splash screen lasts at least two seconds
            timer.Stop();
            int remainingTimeToShowSplash = MINIMUM_SPLASH_TIME - (int)timer.ElapsedMilliseconds;
            if (remainingTimeToShowSplash > 0) {
                Thread.Sleep(remainingTimeToShowSplash);
            }

            // Step 5 - show the page
            splash.Close(TimeSpan.FromMilliseconds(SPLASH_FADE_TIME));
            main.Show();
        }      
    }
}
