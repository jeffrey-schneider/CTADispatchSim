using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CTADispatchSim.Models
{
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

        private string _nextStation;
        public string NextStation
        {
            get => _nextStation;
            set
            {
                if (_nextStation != value)
                {
                    _nextStation = value;
                    OnPropertyChanged(nameof(NextStation));
                }
            }
        }

        private string _previousStation;
        public string PreviousStation
        {
            get => _previousStation;
            set
            {
                if (_previousStation != value)
                {
                    _previousStation = value;
                    OnPropertyChanged(nameof(PreviousStation));
                }
            }
        }

        private Stack<string> StationStack { get; set; }

        public Train(string name, List<string> stations)
        {
            Name = name;
            LoadStations(stations);
        }

        private void LoadStations(List<string> stations)
        {
            if (stations == null || stations.Count == 0)
            {
                StationStack = new Stack<string>();
                CurrentStation = "No Stations Available";
                NextStation = "End of Line";
                return;
            }

            StationStack = new Stack<string>(stations);
            CurrentStation = StationStack.Pop();
            NextStation = StationStack.Count > 0 ? StationStack.Peek() : "End of Line";
        }


        public void MoveToNextStation()
        {
            if (StationStack.Count > 0)
            {
                PreviousStation = CurrentStation;
                CurrentStation = StationStack.Pop();
                NextStation = StationStack.Count > 0 ? StationStack.Peek() : "End of Line";

                // ✅ Handle Looping Lines Specifically
                if (IsLoopStation(CurrentStation) && StationStack.Count == 0)
                {
                    ReloadLoopStations();
                }
            }
            else
            {
                ReverseRoute();
            }
        }

        private void ReloadLoopStations()
        {
            var loopStations = new List<string>
            {
                "Clark/Lake","State/Lake","Washington/Wabash","Adams/Wabash",
                "Harold Washington Library", "LaSalle/Van Buren", "Quincy", "Washington/Wells"
            };

            StationStack = new Stack<string>(loopStations);
            NextStation = StationStack.Peek();
        }

        // ✅ Check if a station is part of The Loop
        private bool IsLoopStation(string station)
        {
            return new List<string>  {
            "Clark/Lake", "State/Lake", "Washington/Wabash", "Adams/Wabash",
            "Harold Washington Library", "LaSalle/Van Buren", "Quincy", "Washington/Wells"
            }.Contains(station);
        }
        


        private void ReverseRoute()
        {
            var reversedList = new List<string> { CurrentStation };
            reversedList.AddRange(StationStack);
            reversedList.Reverse();
            LoadStations(reversedList);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
