using System.Collections.Generic;

namespace MBRD.Boats
{
    public class Fleet
    {
        private List<AbstractBoat> boats;
        
        public Fleet()
        {
            boats = new List<AbstractBoat>();
        }

        public void Add(AbstractBoat boat)
        {
            boats.Add(boat);
        }
    }
}
