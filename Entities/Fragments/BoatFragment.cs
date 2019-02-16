using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MBRD.Entities
{
    class BoatFragment : IPlaceable
    {
        public bool Hit { get; set; }
        public Rectangle Location { get; set; }

        public void Draw(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(contentManager.Load<Texture2D>("Sprites/WaterTiles/46"), Location, Color.White);
        }
    }
}
