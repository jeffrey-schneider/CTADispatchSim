using CTADispatchSim;
using System.Diagnostics;
using System.Windows.Threading;
using System.Windows;

public partial class App : Application
{
    private static DispatcherTimer trainMovementTimer; // ✅ Make it static so all files can access it

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Debug.WriteLine("✅ App startup completed!");

        //Ensure the mainwindow is created and displayed
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();


        if (trainMovementTimer == null)
        {
            Debug.WriteLine("🚀 Initializing train movement timer...");

            trainMovementTimer = new DispatcherTimer();
            trainMovementTimer.Interval = TimeSpan.FromSeconds(3);
            //trainMovementTimer.Tick += MoveTrains;
            trainMovementTimer.Tick += (s, args) => MoveTrains(mainWindow);
            trainMovementTimer.Start();

            Debug.WriteLine("✅ Train movement timer started!");
        }
        else
        {
            Debug.WriteLine("⚠️ Train Movement Timer already running.");
        }
    }

    private void MoveTrains(MainWindow mainWindow)
    {
        Debug.WriteLine("🚆 MoveTrains() Tick");

        foreach (var train in mainWindow.Trains)
        {
            Debug.WriteLine($"🔄 Moving train: {train.Name}");
            train.MoveToNextStation();
        }
    }
    private void MoveTrainsBkup(object sender, EventArgs e)
    {
        Debug.WriteLine("🚀 MoveTrains() Tick");

        foreach (var window in Application.Current.Windows)
        {
            if (window is MainWindow mainWindow)
            {
                foreach (var train in mainWindow.Trains)
                {
                    Debug.WriteLine($"🔄 Triggering MoveToNextStation() for {train.Name}");
                    train.MoveToNextStation();
                }
            }
        }
    }
}
