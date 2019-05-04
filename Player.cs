using MBRD.Boats;
using MBRD.Grids;
using MBRD.TileEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MBRD
{
    public class Player
    {
        public string name { get; set; }
        public Color color { get; set; }
        public int order { get; set; }
        public bool IsActive { get; set; }
        public TileMap boatGrid { get; set; }
        public TileMap firingGrid { get; set; }
        public Fleet fleet { get; set; }



        public Player(string newName, Color newColor, int playerOrder, bool active, TileSet Set)
        {
            name = newName;
            color = newColor;
            order = playerOrder;
            IsActive = active;

            SetupGrids(Set);

            Console.WriteLine("New player created with name {0} playing color {1} and isActive {2}", name, color, active);
        }

        public void AddFleet(Fleet fleet)
        {
            this.fleet = fleet;
            Console.WriteLine("Fleet added to player {0}", name);
        }

        private void SetupGrids(TileSet Set)
        {
            
            //Boat stuff
            TileLayer SeaLayer = new TileLayer(100, 100, 22);
            TileLayer BoatLayer = new TileLayer(100, 100, -1);
            boatGrid = new TileMap(Set, SeaLayer, BoatLayer, "player-boat-map");

            //fire stuff
            TileLayer FiringLayer = new TileLayer(100, 100, 22, 350);
            TileLayer MarkingLayer = new TileLayer(100, 100, -1, 350);
            firingGrid = new TileMap(Set, FiringLayer, MarkingLayer, "player-firing-map");
                       
            Console.WriteLine("SetupGrids for player {0}", name);
        }

        public void Draw(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            //boatGrid.Draw(contentManager, spriteBatch);
            //firingGrid.Draw(contentManager, spriteBatch);
        }
    }    
}
