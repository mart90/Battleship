﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MBRD.Entities
{
    class Player
    {
        public string name { get; set; }
        public string color { get; set; }
        public int order { get; set; }
        public BoatGrid boatGrid { get; set; }
        public FiringGrid firingGrid { get; set; }
        public Fleet fleet { get; set; }


        public Player(string newName, string newColor, int playerOrder)
        {
            name = newName;
            color = newColor;
            order = playerOrder;

            SetupGrids();

            Console.WriteLine("New player created with name {0} and color {1}", name, color);
        }

        public void AddFleet(Fleet fleet)
        {
            this.fleet = fleet;
        }

        private void SetupGrids()
        {

            int horizontalOffset = (order == 1) ? 0 : 520;

            boatGrid = new BoatGrid(10, 10, 50, horizontalOffset, 0);
            firingGrid = new FiringGrid(10, 10, 50, horizontalOffset, 520);
        }

        public void Draw(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            boatGrid.Draw(contentManager, spriteBatch);
            firingGrid.Draw(contentManager, spriteBatch);
        }
    }    
}
