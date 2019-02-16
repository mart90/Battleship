using System;
using System.Collections.Generic;

namespace MBRD.Entities
{
    class Player
    {
        public string name { get; set; }
        public string color { get; set; }
        public BoatGrid boatGrid { get; set; }
        public FiringGrid firingGrid { get; set; }
        public Fleet fleet { get; set; }


        public Player(string newName, string newColor)
        {
            name = newName;
            color = newColor;

            SetupGrids();

            Console.WriteLine("New player created with name {0} and color {1}", name, color);
        }

        public void AddFleet(Fleet fleet)
        {
            this.fleet = fleet;
        }

        private void SetupGrids()
        {
            boatGrid = new BoatGrid(10, 10);
            firingGrid = new FiringGrid(10, 10);
        }
    }    
}
