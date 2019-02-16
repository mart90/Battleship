using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MBRD.Entities
{
    class WaterFragment : IPlaceable
    {
        public bool Hit { get; set; }
        public Rectangle Location { get; set; }

        public void Draw(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(contentManager.Load<Texture2D>("Sprites/WaterTiles/48"), Location, Color.White);
        }
    }
}
