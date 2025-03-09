// TrackView.xaml.cs
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Data;
using System.Globalization;

namespace CTADispatchSim.Views
{
    public partial class TrackView : UserControl
    {
        public TrackView()
        {
            InitializeComponent();
        }
    }
}

namespace CTADispatchSim.Converters
{
    public class BoolToStatusConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isAvailable)
                return isAvailable ? "Available" : "Occupied";
            return "Unknown";
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString() == "Available";
        }
    }
}