using MBRD.Boats;
using MBRD.Grids;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MBRD
{
    class Player
    {
        public string name { get; set; }
        public Color color { get; set; }
        public int order { get; set; }
        public bool IsActive { get; set; }
        public BoatGrid boatGrid { get; set; }
        public FiringGrid firingGrid { get; set; }
        public Fleet fleet { get; set; }


        public Player(string newName, Color newColor, int playerOrder, bool active)
        {
            name = newName;
            color = newColor;
            order = playerOrder;
            IsActive = active;

            //SetupGrids();

            Console.WriteLine("New player created with name {0} playing color {1} and isActive {2}", name, color, active);
        }

        public void AddFleet(Fleet fleet)
        {
            this.fleet = fleet;
            Console.WriteLine("Fleet added to player {0}", name);
        }

        private void SetupGrids()
        {

            int horizontalOffset = (order == 1) ? 0 : 520;

            boatGrid = new BoatGrid(10, 10, 50, horizontalOffset, 0);
            firingGrid = new FiringGrid(10, 10, 50, horizontalOffset, 520);

            Console.WriteLine("SetupGrids for player {0}", name);
        }

        public void Draw(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            //boatGrid.Draw(contentManager, spriteBatch);
            //firingGrid.Draw(contentManager, spriteBatch);
        }
    }    
}
