using MBRD.Boats;
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



        public Player(string newName, Color newColor, int playerOrder, bool active, TileSet SeaSet, TileSet BoatSet)
        {
            name = newName;
            color = newColor;
            order = playerOrder;
            IsActive = active;

            SetupGrids(SeaSet, BoatSet);

            Console.WriteLine("New player created with name {0} playing color {1} and isActive {2}", name, color, active);
        }

        public void AddFleet(Fleet fleet)
        {
            this.fleet = fleet;
            Console.WriteLine("Fleet added to player {0}", name);
        }

        private void SetupGrids(TileSet SeaSet, TileSet BoatSet)
        {
            //Boat stuff
            TileLayer SeaLayer = new TileLayer(200, 200, 22);
            TileLayer BoatLayer = new TileLayer(200, 200, -1);
            boatGrid = new TileMap(SeaSet, BoatSet, SeaLayer, BoatLayer, "player-boat-map");

            if(name == "Player 1")
            {
                boatGrid.SetBoatTile(0, 0, 1);
                boatGrid.SetBoatTile(0, 1, 1);
            } else
            {
                boatGrid.SetBoatTile(0, 0, 0);
            }
            

            //fire stuff
            TileLayer FiringLayer = new TileLayer(100, 100, 22, 500);
            TileLayer MarkingLayer = new TileLayer(100, 100, -1, 500);
            firingGrid = new TileMap(SeaSet, BoatSet, FiringLayer, MarkingLayer, "player-firing-map");
                       
            Console.WriteLine("SetupGrids for player {0}", name);
        }

        public void Draw(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            //boatGrid.Draw(contentManager, spriteBatch);
            //firingGrid.Draw(contentManager, spriteBatch);
        }
    }    
}
