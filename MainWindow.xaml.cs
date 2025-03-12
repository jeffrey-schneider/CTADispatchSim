using CTADispatchSim.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace CTADispatchSim
{

      
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Train> Trains { get; set; } = new ObservableCollection<Train>();
       
        private DispatcherTimer trainMovementTimer;


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Debug.WriteLine("✅ MainWindow constructor started!"); // Debug Message
            
            LoadTrains();
            
            trainMovementTimer = new DispatcherTimer();
            trainMovementTimer.Interval = TimeSpan.FromSeconds(3); //move trains every 3 seconds
            trainMovementTimer.Tick += MoveTrains;
            trainMovementTimer.Start();

            Debug.WriteLine("🚆 Train movement timer started!"); // Debug message
        }

        public void StartTrainTimer()
        {
            if(trainMovementTimer != null)
            {
                trainMovementTimer.Start();
                Debug.WriteLine("🚀 Train movement timer started manually from OnStartup!");            
            }
        }




        private void MoveTrains(object sender, EventArgs e)
        {
            foreach (var train in Trains)
            {
                train.MoveToNextStation();
                Debug.WriteLine($"🚆 {train.Name} moved to {train.CurrentStation}. Next stop: {train.NextStation}");
            }
        }

        private void LoadTrains()
        {
            Trains.Add(new Train("Yellow Line Train 101", CTAStations.LineStations["Yellow"]));
            Trains.Add(new Train("Red Line Train 201", CTAStations.LineStations["Red"]));
            Trains.Add(new Train("Blue Line Train 301", CTAStations.LineStations["Blue"]));
            Trains.Add(new Train("Green Line Train 901", CTAStations.LineStations["Green"]));
            Trains.Add(new Train("Pink Line Train 902", CTAStations.LineStations["Pink"]));
            Trains.Add(new Train("Orange Line Train 903", CTAStations.LineStations["Orange"]));
            Trains.Add(new Train("Brown Line Train 904", CTAStations.LineStations["Brown"]));
            Trains.Add(new Train("Purple Line Train 905", CTAStations.LineStations["Purple"]));

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
