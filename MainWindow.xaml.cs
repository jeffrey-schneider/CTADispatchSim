using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace CTADispatchSim
{
    //jeff was here.
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Train> Trains { get; set; } = new ObservableCollection<Train>();
        public ObservableCollection<TrackBlock> TrackBlocks { get; set; } = new ObservableCollection<TrackBlock>();

        private TrackBlock _testTrackBlock;
        private DispatcherTimer trainMovementTimer;


        public TrackBlock TestTrackBlock
        {
            get => _testTrackBlock;
            set
            {
                _testTrackBlock = value;
                OnPropertyChanged(nameof(TestTrackBlock));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Debug.WriteLine("✅ MainWindow constructor started!"); // Debug Message
            
            LoadTracks();
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
        private void MoveTrains(object? sender, EventArgs e)
        {
            Debug.WriteLine("Move trains called!");
            foreach (var train in Trains)
            {
                Debug.WriteLine($"🚆 {train.Name} is at {train.CurrentStation}");
                //find the current track where the train is located
                var currentTrack = TrackBlocks.FirstOrDefault(t => t.StartStation == train.CurrentStation);

                if (currentTrack != null)
                {
                    train.CurrentStation = currentTrack.EndStation;
                    Debug.WriteLine($"➡ {train.Name} moved to {train.CurrentStation}");

                }
                else
                {
                    //train reached last station, loop it back
                    train.CurrentStation = TrackBlocks.First().StartStation;
                    Debug.WriteLine($"🔄 {train.Name} looped back to {train.CurrentStation}");
                }

                OnPropertyChanged(nameof(Trains));
            }
        }

        private void LoadTracks()
        {
            // Placeholder track data
            TrackBlocks.Add(new TrackBlock("Howard", "Oakton", true));
            TrackBlocks.Add(new TrackBlock("Oakton", "Dempster", true));
            TrackBlocks.Add(new TrackBlock("Dempster", "Skokie", true));

            TestTrackBlock = new TrackBlock("Howard", "Oakton", true); // Now triggers UI update
        }

        private void LoadTrains()
        {
            Trains.Add(new Train("Train 101", "Howard"));
            Trains.Add(new Train("Train 202", "Dempster"));
            Trains.Add(new Train("Train 303", "Skokie"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

   

public class Train : INotifyPropertyChanged
    {
        public string Name { get; set; }

        private string _currentStation;
        public string CurrentStation
        {
            get => _currentStation;
            set
            {
                if (_currentStation != value)
                {
                    _currentStation = value;
                    OnPropertyChanged(nameof(CurrentStation));
                }
            }
        }

        public Train(string name, string station)
        {
            Name = name;
            _currentStation = station;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class TrackBlock : INotifyPropertyChanged
    {
        public string StartStation { get; set; }
        public string EndStation { get; set; }

        private bool _isAvailable;
        public bool IsAvailable
        {
            get => _isAvailable;
            set
            {
                if (_isAvailable != value)
                {
                    _isAvailable = value;
                    OnPropertyChanged(nameof(IsAvailable));
                }
            }
        }

        public TrackBlock(string start, string end, bool available)
        {
            StartStation = start;
            EndStation = end;
            _isAvailable = available;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
