using CTADispatchSim.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace CTADispatchSim
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private DispatcherTimer trainMovementTimer;
        private DispatcherTimer clockTimer;
        private DateTime simulationTime;

        public ObservableCollection<Train> Trains { get; set; } = new ObservableCollection<Train>();

        private string _simulationTimeString;
        public string SimulationTime
        {
            get => _simulationTimeString;
            set
            {
                if (_simulationTimeString != value)
                {
                    _simulationTimeString = value;
                    OnPropertyChanged(nameof(SimulationTime));
                }
            }
        }

        public MainWindow()
        {
            Debug.WriteLine("✅ MainWindow constructor started!");

            InitializeComponent();
            BuildYellowLineGraph();

            DataContext = this;

            simulationTime = DateTime.Now;
            StartClock();

            LoadTrains();

            trainMovementTimer = new DispatcherTimer();
            trainMovementTimer.Interval = TimeSpan.FromSeconds(3);
            trainMovementTimer.Tick += MoveTrains;
            trainMovementTimer.Start();

            Debug.WriteLine("🚀 Train movement timer started!");
        }

        private void LoadTrains()
        {
            Trains.Add(new Train("Yellow Line Train 101", "Yellow", CTAStations.LineStations["Yellow"], "#FFD700", "#000000"));
            Trains.Add(new Train("Red Line Train 201", "Red", CTAStations.LineStations["Red"], "#FF0000", "#FFFFFF"));
            Trains.Add(new Train("Blue Line Train 301", "Blue", CTAStations.LineStations["Blue"], "#0000FF", "#FFFFFF"));
            Trains.Add(new Train("Green Line Train 901", "Green", CTAStations.LineStations["Green"], "#008000", "#FFFFFF"));
            Trains.Add(new Train("Pink Line Train 902", "Pink", CTAStations.LineStations["Pink"], "#FFC0CB", "#000000"));
            Trains.Add(new Train("Orange Line Train 903", "Orange", CTAStations.LineStations["Orange"], "#FFA500", "#000000"));
            Trains.Add(new Train("Brown Line Train 904", "Brown", CTAStations.LineStations["Brown"], "#8B4513", "#FFFFFF"));
            Trains.Add(new Train("Purple Line Train 905", "Purple", CTAStations.LineStations["Purple"], "#800080", "#FFFFFF"));

            Debug.WriteLine("🚆 Trains loaded successfully!");
        }

        private void MoveTrains(object sender, EventArgs e)
        {
            foreach (var train in Trains)
            {
                if (train.CurrentStation == null)
                    continue;

                string previousStation = train.CurrentStation.StationName;
                train.MoveToNextStation();

                Debug.WriteLine($"🚆 {train.Name} moved from {previousStation} to {train.CurrentStation.StationName}");

                // 🚨 Handle "Change Tracks" stations
                if (train.CurrentStation.StationName.StartsWith("Change Tracks"))
                {
                    Debug.WriteLine($"🔄 {train.Name} reached {train.CurrentStation.StationName} and is preparing to continue.");
                }
            }
        }


        private void StartClock()
        {
            simulationTime = new DateTime(2025, 3, 16, 4, 0, 0);  

            clockTimer = new DispatcherTimer();
            clockTimer.Interval = TimeSpan.FromSeconds(1);
            clockTimer.Tick += (s, e) =>
            {
                simulationTime = simulationTime.AddMinutes(1);
                SimulationTime = simulationTime.ToString("HH:mm:ss");
            };
            clockTimer.Start();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (trainMovementTimer.IsEnabled || clockTimer.IsEnabled)
            {
                trainMovementTimer.Stop();
                clockTimer.Stop();
                Debug.WriteLine("⏸ Simulation Paused");
                PauseButton.Content = "Resume";
            }
            else
            {
                trainMovementTimer.Start();
                clockTimer.Start();
                Debug.WriteLine("▶ Simulation Resumed");
                PauseButton.Content = "Pause";
            }
        }

        private Dictionary<string, TrackBlock> _trackBlocks = new();

        private void BuildYellowLineGraph()
        {
            // Define the Yellow Line block segments
            var segments = new List<string>
    {
        "Howard → Oakton/Skokie",
        "Oakton/Skokie → Dempster/Skokie",
        "Dempster/Skokie → Oakton/Skokie",
        "Oakton/Skokie → Howard"
    };

            foreach (var seg in segments)
            {
                var block = new TrackBlock(seg);
                _trackBlocks[seg] = block;
                LineDisplayPanel.Children.Add(block);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
