using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MBRD.TileEngine
{
    class TileMap
    {
        #region Field Region
        string mapName;
        TileLayer seaLayer;
        TileLayer boatLayer;

        Dictionary<string, Point> characters;
        [ContentSerializer]
        int mapWidth;
        [ContentSerializer]
        int mapHeight;
        TileSet tileSet;
        #endregion
        
        #region Property Region
        [ContentSerializer]
        public string MapName
        {
            get { return mapName; }
            private set { mapName = value; }
        }
        [ContentSerializer]
        public TileSet TileSet
        {
            get { return tileSet; }
            set { tileSet = value; }
        }
        [ContentSerializer]
        public TileLayer SeaLayer
        {
            get { return seaLayer; }
            set { seaLayer = value; }
        }
        [ContentSerializer]
        public TileLayer BoatLayer
        {
            get { return boatLayer; }
            set { boatLayer = value; }
        }
       
        [ContentSerializer]
        public Dictionary<string, Point> Characters
        {
            get { return characters; }
            private set { characters = value; }
        }
        public int MapWidth
        {
            get { return mapWidth; }
        }
        public int MapHeight
        {
            get { return mapHeight; }
        }
        public int WidthInPixels
        {
            get { return mapWidth * Engine.TileWidth; }
        }
        public int HeightInPixels
        {
            get { return mapHeight * Engine.TileHeight; }
        }
        #endregion
        #region Constructor Region
        private TileMap()
        {
        }
        private TileMap(TileSet tileSet, string mapName)
        {
            this.characters = new Dictionary<string, Point>();
            this.tileSet = tileSet;
            this.mapName = mapName;
        }
        public TileMap(TileSet tileSet, TileLayer seaLayer, TileLayer boatLayer, string mapName)
        : this(tileSet, mapName)
        {
            this.seaLayer = seaLayer;
            this.boatLayer = boatLayer;
            mapWidth = seaLayer.Width;
            mapHeight = seaLayer.Height;
        }
        #endregion
        #region Method Region
        public void SetSeaTile(int x, int y, int index)
        {
            seaLayer.SetTile(x, y, index);
        }
        public int GetSeaTile(int x, int y)
        {
            return seaLayer.GetTile(x, y);
        }
        
        public void Update(GameTime gameTime)
        {
            if (seaLayer != null)
                seaLayer.Update(gameTime);
            if (boatLayer != null)
                boatLayer.Update(gameTime);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (seaLayer != null)
                seaLayer.Draw(gameTime, spriteBatch, tileSet);
            if (boatLayer != null)
                boatLayer.Draw(gameTime, spriteBatch, tileSet);
        }
        #endregion
    }
}
