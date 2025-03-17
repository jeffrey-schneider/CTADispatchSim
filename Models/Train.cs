using CTADispatchSim.Helpers;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media; // Needed for color binding in WPF

namespace CTADispatchSim.Models
{
    public class Train : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Route { get; set; } // Train's route name
        public SolidColorBrush RouteColor { get; set; }
        public SolidColorBrush RouteTextColor { get; set; }

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
        

        private List<string> OriginalStations; // Backup of original station list

        public ICommand RestartCommand { get; private set; }

        public Train(string name, string route, List<string> stations, string routeColor, string routeTextColor)
        {
            Name = name;
            Route = route;
            RouteColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(routeColor));
            RouteTextColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(routeTextColor));
            OriginalStations = new List<string>(stations); // 🔄 Store original station list
            LoadStations(stations);
            RestartCommand = new RelayCommand(RestartTrain);
            //RestartCommand = new RelayCommand(param => RestartTrain(param ?? "Manual Restart"));

        }

        
        
        private void LoadStations(List<string> stations)
        {

            if (stations == null || stations.Count == 0)
                throw new ArgumentException("Station list cannot be null or empty");
            
                StationStack = new Stack<string>(stations);

            CurrentStation = StationStack.Pop();
            NextStation = StationStack.Count > 0 ? StationStack.Peek() : "End of Line";
            PreviousStation = "None";
        }

        // 🚀 Do NOT reverse, since Yellow Line already includes both directions!





   


        public async void MoveToNextStation()
        {
            Debug.WriteLine($"📍 {Name} Current: {CurrentStation}, Next: {NextStation}");

            if (StationStack.Count > 0)
            {
                PreviousStation = CurrentStation;
                CurrentStation = StationStack.Pop();
                NextStation = StationStack.Count > 0 ? StationStack.Peek() : null; // ❌ Fix: Remove "End of Line"

                Debug.WriteLine($"🚆 {Name} moved to {CurrentStation}. Next stop: {NextStation ?? "End of Route"}");
            }

            if (StationStack.Count == 0) // 🛑 Reached the end
            {
                Debug.WriteLine($"🛑 {Name} reached {CurrentStation}. Restarting in 10 seconds...");
                await Task.Delay(TimeSpan.FromSeconds(10));
                RestartTrain();
            }
        }






        private void ReverseRoute()
        {
            var reversedList = new List<string> { CurrentStation };
            reversedList.AddRange(StationStack);
            reversedList.Reverse();
            LoadStations(reversedList);
        }

        public void RestartTrain()
        {
            Debug.WriteLine($"🟢 {Name} is restarting its route.");

            if (OriginalStations == null || OriginalStations.Count == 0)
            {
                Debug.WriteLine($"⚠ ERROR: {Name} has no original stations stored!");
                return;
            }

            LoadStations(new List<string>(OriginalStations));

            // ✅ Explicitly reset to the first station
            CurrentStation = OriginalStations[0];
            //NextStation = OriginalStations.Count > 1 ? OriginalStations[1] : null;
            

            OnPropertyChanged(nameof(CurrentStation));
            OnPropertyChanged(nameof(NextStation));
            OnPropertyChanged(nameof(PreviousStation));

            Debug.WriteLine($"🔄 {Name} Restarted! First station: {CurrentStation}, Next: {NextStation}");
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
