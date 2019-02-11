using ChatApp.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //custom startup, which allows for making the IoC load before anything else
        protected override void OnStartup(StartupEventArgs e)
        {
            //Let the application do what it does 
            base.OnStartup(e);

            //Setting up the IoC
            IoC.Setup();

            // show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
