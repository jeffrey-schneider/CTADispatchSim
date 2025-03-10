using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace CTADispatchSim
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Debug.WriteLine("✅ App Startup completed!");

            //Now call the public method to srate the train timer
            mainWindow.StartTrainTimer();
        }
    }

}
