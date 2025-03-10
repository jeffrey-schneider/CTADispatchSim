using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace CTADispatchSim
{

    public enum TrackDirection
    {
        Inbound,
        Outbound
    }

    
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
        private void MoveTrains(object sender, EventArgs e)
        {
            foreach (var train in Trains)
            {
                Debug.WriteLine($"🚆 {train.Name} is at {train.CurrentStation}");

                // Find the correct track based on the train's direction
                var currentTrack = TrackBlocks.FirstOrDefault(t =>
                    t.StartStation == train.CurrentStation &&
                    (train.Direction == TrackDirection.Inbound ? t.Direction == TrackDirection.Inbound : t.Direction == TrackDirection.Outbound)
                );

                if (currentTrack != null)
                {
                    train.CurrentStation = currentTrack.EndStation;
                    Debug.WriteLine($"➡ {train.Name} moved to {train.CurrentStation}");
                }
                else
                {
                    // Train reached end of the route, loop it back
                    var resetTrack = TrackBlocks.FirstOrDefault(t => t.Direction == (train.Direction == TrackDirection.Inbound ? TrackDirection.Outbound : TrackDirection.Inbound));
                    if (resetTrack != null)
                    {
                        train.CurrentStation = resetTrack.StartStation;
                        train.Direction = train.Direction == TrackDirection.Inbound ? TrackDirection.Outbound : TrackDirection.Inbound;
                        Debug.WriteLine($"🔄 {train.Name} reversed direction and is now at {train.CurrentStation}");
                    }
                }
            }
        }


        private void LoadTracks()
        {
            // Example Yellow Line (Skokie Swift) with Inbound and Outbound tracks
            TrackBlocks.Add(new TrackBlock("Dempster-Skokie", "Oakton-Skokie", TrackDirection.Inbound, true));
            TrackBlocks.Add(new TrackBlock("Oakton-Skokie", "Howard", TrackDirection.Inbound, true));

            TrackBlocks.Add(new TrackBlock("Howard", "Oakton-Skokie", TrackDirection.Outbound, true));
            TrackBlocks.Add(new TrackBlock("Oakton-Skokie", "Dempster-Skokie", TrackDirection.Outbound, true));
        }

        private void LoadTrains()
        {
            Trains.Add(new Train("Train 101", "Dempster-Skokie", TrackDirection.Inbound));
            Trains.Add(new Train("Train 202", "Howard", TrackDirection.Outbound));
            Trains.Add(new Train("Train 303", "Oakton-Skokie", TrackDirection.Inbound));
            Trains.Add(new Train("Train 404", "Oakton-Skokie", TrackDirection.Outbound));
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

        private TrackDirection _direction;
        public TrackDirection Direction
        {
            get => _direction;
            set
            {
                if (_direction != value)
                {
                    _direction = value;
                    OnPropertyChanged(nameof(Direction));
                }
            }
        }

        public Train(string name, string station, TrackDirection direction)
        {
            Name = name;
            _currentStation = station;
            _direction = direction;
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
        public TrackDirection Direction { get; set; }

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

        public TrackBlock(string start, string end, TrackDirection direction, bool available)
        {
            StartStation = start;
            EndStation = end;
            Direction = direction;
            _isAvailable = available;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
