using System;
using System.Collections.Generic;

namespace _03ShortestPathBetweenJunctions
{
    public class Junction : IComparable<Junction>
    {        
        public Junction(string name)
        {
            this.Name = name;            
            this.IsVisited = false;
            this.Cost = int.MaxValue;
            this.ConnectionComponentId = 0;
            this.Previous = null;
            this.Children = new Dictionary<Junction, int>();
        }

        public string Name { get; }

        public bool IsVisited { get; set; }        

        public int Cost { get; set; }        

        public int ConnectionComponentId { get; set; }

        public Junction Previous { get; set; }

        public Dictionary<Junction, int> Children { get; set; }        

        public void ResetCostAndPrevious()
        {
            this.Cost = int.MaxValue;
            this.Previous = null;
            this.IsVisited = false;
        }

        public override bool Equals(Object junctionObject)
        {
            if (this == junctionObject)
            {
                return true;
            }

            Junction junction = junctionObject as Junction;
            if (junction == null)
            {
                return false;
            }

            if (!this.Name.Equals(junction.Name))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public int CompareTo(Junction otherJunction)
        {
            return this.Cost.CompareTo(otherJunction.Cost);
        }
    }
}
