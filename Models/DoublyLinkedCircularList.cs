using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTADispatchSim.Models
{
    public class DoublyLinkedCircularList
    {
        public StationNode Head { get; private set; }

        public DoublyLinkedCircularList(List<(string Station, double Distance)> stations)
        {
            if (stations == null || stations.Count == 0)
                throw new ArgumentNullException("Station list cannot be empty.");

            //Create nodes
            StationNode prevNode = null;
            foreach(var(station,distance) in stations)
            {
                var newNode = new StationNode(station, distance);
                if(Head == null)
                {
                    Head = newNode;
                }
                else
                {
                    prevNode.Next = newNode;
                    newNode.Previous = prevNode;
                }
                prevNode = newNode;
            }

            //Make it circular
            prevNode.Next = Head;
            Head.Previous = prevNode;
        }
        public StationNode GetNextStation(StationNode current, bool forward = true)
        {
            return forward ? current.Next : current.Previous;
        }

    }
}
