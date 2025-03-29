using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows;

namespace CTADispatchSim
{
    public class TrackBlock : Border
    {
        public string BlockId { get; set; }

        private bool _isOccupied;
        public bool IsOccupied
        {
            get => _isOccupied;
            set
            {
                _isOccupied = value;
                Background = value ? Brushes.OrangeRed : Brushes.LightGreen;
            }
        }

        public TrackBlock(string blockId)
        {
            BlockId = blockId;
            Width = 150;
            Height = 60;
            Margin = new Thickness(5);
            CornerRadius = new CornerRadius(10);
            BorderBrush = Brushes.Black;
            BorderThickness = new Thickness(2);
            Background = Brushes.LightGreen;

            Child = new TextBlock
            {
                Text = blockId,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center
            };
        }
    }
}