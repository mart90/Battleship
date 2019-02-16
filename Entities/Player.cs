using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MBRD.Entities
{
    class Player
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public BoatGrid BoatGrid { get; set; }
        public FiringGrid FiringGrid { get; set; }
        public Fleet Fleet { get; set; }

        public Player(string newName, string newColor)
        {
            Name = newName;
            Color = newColor;

            SetupGrids();

            Console.WriteLine("New player created with name {0} and color {1}", Name, Color);
        }

        public void AddFleet(Fleet fleet)
        {
            this.Fleet = fleet;
        }

        private void SetupGrids()
        {
            BoatGrid = new BoatGrid(10, 10, 50);
            FiringGrid = new FiringGrid(10, 10, 50);
        }

        public void Draw(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            BoatGrid.Draw(contentManager, spriteBatch);
            //firingGrid.Draw(contentManager, spriteBatch);
        }
    }    
}
