using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBRD.TileEngine
{
    public class Engine
    {
        #region Fields
        private static Rectangle viewPortRectangle;
        private static int tileWidth = 32;
        private static int tileHeight = 32;
        private TileMap map;
        #endregion

        #region Property Region
        public static int TileWidth
        {
            get { return tileWidth; }
            set { tileWidth = value; }
        }
        public static int TileHeight
        {
            get { return tileHeight; }
            set { tileHeight = value; }
        }
        public TileMap Map
        {
            get { return map; }
        }
        public static Rectangle ViewportRectangle
        {
            get { return viewPortRectangle; }
            set { viewPortRectangle = value; }
        }
        #endregion

        #region Constructors
        public Engine(Rectangle viewPort)
        {
            ViewportRectangle = viewPort;
            TileWidth = 64;
            TileHeight = 64;
        }
        public Engine(Rectangle viewPort, int tileWidth, int tileHeight)
        : this(viewPort)
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
        }
        #endregion

        #region Methods
        public static Point VectorToCell(Vector2 position)
        {
            return new Point((int)position.X / tileWidth, (int)position.Y / tileHeight);
        }
        public void SetMap(TileMap newMap)
        {
            if (newMap == null)
            {
                throw new ArgumentNullException("newMap");
            }
            map = newMap;
        }
        public void Update(GameTime gameTime)
        {
            Map.Update(gameTime);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Map.Draw(gameTime, spriteBatch);
        }

        #endregion

    }
}
