using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MBRD.TileEngine
{
    class TileSet
    {
        #region Fields and Properties
        public int TilesWide = 8;
        public int TilesHigh = 8;
        public int TileWidth = 64;
        public int TileHeight = 64;
                
        Texture2D image;
        string imageName;
        Rectangle[] sourceRectangles;
        #endregion
        
        #region Property Region
        [ContentSerializerIgnore]
        public Texture2D Texture
        {
            get { return image; }
            set { image = value; }
        }
        [ContentSerializer]
        public string TextureName
        {
            get { return imageName; }
            set { imageName = value; }
        }
        [ContentSerializerIgnore]
        public Rectangle[] SourceRectangles
        {
            get { return (Rectangle[])sourceRectangles.Clone(); }
        }
        #endregion
        #region Constructor Region
        public TileSet()
        {
            sourceRectangles = new Rectangle[TilesWide * TilesHigh];
            int tile = 0;
            for (int y = 0; y < TilesHigh; y++)
                for (int x = 0; x < TilesWide; x++)
                {
                    sourceRectangles[tile] = new Rectangle(
                    x * TileWidth,
                    y * TileHeight,
                    TileWidth,
                    TileHeight);
                    tile++;
                }
        }
        public TileSet(int tilesWide, int tilesHigh, int tileWidth, int tileHeight)
        {
            TilesWide = tilesWide;
            TilesHigh = tilesHigh;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            sourceRectangles = new Rectangle[TilesWide * TilesHigh];
            int tile = 0;
            for (int y = 0; y < TilesHigh; y++)
                for (int x = 0; x < TilesWide; x++)
                {
                    sourceRectangles[tile] = new Rectangle(
                    x * TileWidth,
                    y * TileHeight,
                    TileWidth,
                    TileHeight);
                    tile++;
                }
        }

        #endregion
        #region Method Region
        #endregion    }
}
