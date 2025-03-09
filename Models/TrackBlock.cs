namespace CTADispatchSim.Models
{
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
