using CTADispatchSim.Models;
using CTADispatchSim.Services;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Media;

public class Train : INotifyPropertyChanged
{
    public string Name { get; set; }
    public string Route { get; set; }
    public SolidColorBrush RouteColor { get; set; }
    public SolidColorBrush RouteTextColor { get; set; }
    private DoublyLinkedCircularList RouteList;
    private StationNode _currentStation;

    public StationNode CurrentStation
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

    public Train(string name, string route, List<(string Station, double Distance)> stations, string routeColor, string routeTextColor)
    {
        Name = name;
        Route = route;
        RouteList = new DoublyLinkedCircularList(stations);
        CurrentStation = RouteList.Head;

        // Assign colors
        RouteColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(routeColor));
        RouteTextColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(routeTextColor));
        PrintGreenLineRoute();
    }

    public void MoveToNextStation()
    {
        if (Route == "Green" && CurrentStation.StationName == "Garfield")
        {
            DispatchService dispatchService = new DispatchService();
            dispatchService.MoveTrain(this);
        }
        else
        {
            CurrentStation = CurrentStation.Next;
        }

        OnPropertyChanged(nameof(CurrentStation));
    }

    public void PrintGreenLineRoute()
    {
        StationNode node = RouteList.Head;
        Debug.WriteLine( "Debug: Green Line Route:");
        do
        {
            Debug.Write($"{node.StationName} → ");
            node = node.Next;
        } while (node != null && node != RouteList.Head);

        Debug.WriteLine("END\n");
    }

    // 🔄 PropertyChanged for UI Updates
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
