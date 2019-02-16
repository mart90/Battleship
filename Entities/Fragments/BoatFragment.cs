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
            Rectangle rect = IconSpriteRectangleFactory.GetRectangle(3, 16);
            spriteBatch.Draw(contentManager.Load<Texture2D>("icon-sprite"), Location, rect, Color.White);
        }
    }
}
