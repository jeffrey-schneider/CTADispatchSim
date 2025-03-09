using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace CTADispatchSim
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Train> Trains { get; set; } = new ObservableCollection<Train>();
        public ObservableCollection<TrackBlock> TrackBlocks { get; set; } = new ObservableCollection<TrackBlock>();

        private TrackBlock _testTrackBlock;
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
            LoadTracks();
            LoadTrains();
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
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Train
    {
        public string Name { get; set; }
        public string CurrentStation { get; set; }

        public Train(string name, string station)
        {
            Name = name;
            CurrentStation = station;
        }
    }

    public class TrackBlock
    {
        public string StartStation { get; set; }
        public string EndStation { get; set; }
        public bool IsAvailable { get; set; }

        public TrackBlock(string start, string end, bool available)
        {
            StartStation = start;
            EndStation = end;
            IsAvailable = available;
        }
    }
}
