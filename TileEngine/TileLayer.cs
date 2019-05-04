using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MBRD.TileEngine
{
    public class TileLayer
    {
        #region Field Region
        [ContentSerializer(CollectionItemName = "Tiles")]
        int[] tiles;
        int width;
        int height;
        int offset;

        Point min;
        Point max;

        Rectangle destination;
        #endregion
        #region Property Region
        [ContentSerializerIgnore]
        public bool Enabled { get; set; }
        [ContentSerializerIgnore]
        public bool Visible { get; set; }
        [ContentSerializer]
        public int Width
        {
            get { return width; }
            private set { width = value; }
        }
        [ContentSerializer]
        public int Height
        {
            get { return height; }
            private set { height = value; }
        }
        #endregion
        #region Constructor Region
        private TileLayer()
        {
            Enabled = true;
            Visible = true;
        }
        public TileLayer(int[] tiles, int width, int height)
        : this()
        {
            this.tiles = (int[])tiles.Clone();
            this.width = width;
            this.height = height;
        }
        public TileLayer(int width, int height)
        : this()
        {
            tiles = new int[height * width];
            this.width = width;
            this.height = height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    tiles[y * width + x] = 0;
                }
            }
        }
        public TileLayer(int width, int height, int fill, int offset = 0)
        : this()
        {
            tiles = new int[height * width];
            this.width = width;
            this.height = height;
            this.offset = offset;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    tiles[y * width + x] = fill;
                }
            }
        }
        #endregion
        #region Method Region
        public int GetTile(int x, int y)
        {
            if (x < 0 || y < 0)
                return -1;
            if (x >= width || y >= height)
                return -1;
            return tiles[y * width + x];
        }
        public void SetTile(int x, int y, int tileIndex)
        {
            if (x < 0 || y < 0)
                return;
            if (x >= width || y >= height)
                return;
            tiles[y * width + x] = tileIndex;
        }
        public void Update(GameTime gameTime)
        {
            if (!Enabled)
                return;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, TileSet tileSet)
        {
            if (!Visible)
                return;

            destination = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);
            int tile;
            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp
            );

            min.X = 0;
            min.Y = 0;
            max.X = 10;
            max.Y = 10;

            for (int y = min.Y; y < max.Y; y++)
            {
                destination.Y = y * Engine.TileHeight;
                for (int x = min.X; x < max.X; x++)
                {
                    tile = GetTile(x, y);
                    if (tile == -1)
                        continue;
                    destination.X = (x * Engine.TileWidth) + offset;
                    spriteBatch.Draw(
                        tileSet.Texture, //texture
                        destination, //rect
                        tileSet.SourceRectangles[tile],//rect
                        Color.White //color
                    );

                   
                }
            }
            spriteBatch.End();
        }
        #endregion
    }
}
