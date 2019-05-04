using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MBRD.TileEngine
{
    public class TileMap
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
        TileSet seaTileSet;
        TileSet boatTileSet;
        #endregion

        #region Property Region
        [ContentSerializer]
        public string MapName
        {
            get { return mapName; }
            private set { mapName = value; }
        }
        [ContentSerializer]
        public TileSet SeaTileSet
        {
            get { return seaTileSet; }
            set { seaTileSet = value; }
        }
        [ContentSerializer]
        public TileSet BoatTileSet
        {
            get { return boatTileSet; }
            set { boatTileSet = value; }
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
        private TileMap(TileSet seaTileSet, TileSet boatTileSet, string mapName)
        {
            this.characters = new Dictionary<string, Point>();
            this.seaTileSet = seaTileSet;
            this.boatTileSet = boatTileSet;
            this.mapName = mapName;
        }
        public TileMap(TileSet seaTileSet, TileSet boatTileSet, TileLayer seaLayer, TileLayer boatLayer, string mapName)
        : this(seaTileSet, boatTileSet, mapName)
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

        public void SetBoatTile(int x, int y, int index)
        {
            boatLayer.SetTile(x, y, index);
        }
        public int GetBoatTile(int x, int y)
        {
            return boatLayer.GetTile(x, y);
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
                seaLayer.Draw(gameTime, spriteBatch, seaTileSet);
            if (boatLayer != null)
                boatLayer.Draw(gameTime, spriteBatch, boatTileSet);
        }
        #endregion
    }
}
