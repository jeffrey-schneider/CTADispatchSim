using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTADispatchSim.Models
{
    public class StationNode
    {
        public string StationName { get; set; }
        public double DistanceToNext { get; set; }
        public StationNode Next { get; set; }
        public StationNode Previous { get; set; }

        public StationNode(string name, double distanceToNext)
        {
            StationName = name;
            DistanceToNext = distanceToNext;
            Next = null;
            Previous = null;
        }
    }
}
