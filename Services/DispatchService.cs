using CTADispatchSim.Models;

namespace CTADispatchSim.Services
{
    public class DispatchService
    {
        private static bool isNextToCottageGrove = true; // Alternating switch for Garfield

        public void MoveTrain(Train train)
        {
            if (train.Route == "Green" && train.CurrentStation.StationName == "Garfield")
            {
                if (isNextToCottageGrove)
                {
                    train.CurrentStation = train.CurrentStation.FindStation("King Drive"); // Route to Cottage Grove
                }
                else
                {
                    train.CurrentStation = train.CurrentStation.FindStation("Halsted"); // Route to Ashland/63rd
                }

                // Toggle for the next train
                isNextToCottageGrove = !isNextToCottageGrove;
            }
            else
            {
                // Default station movement
                train.MoveToNextStation();
            }
        }
    }
}
