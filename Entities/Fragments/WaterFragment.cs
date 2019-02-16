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
            Rectangle rect = new Rectangle(0, 64, 32, 32);
            Vector2 pos = new Vector2(100, 100);
            Vector2 origin = new Vector2(0, 0);

            spriteBatch.Draw(contentManager.Load<Texture2D>("icon-sprite"), 
                pos, 
                rect, 
                Color.Wheat, 
                0.0f,
                origin, 
                1, 
                SpriteEffects.None, 
                0.0f);

            //spriteBatch.Draw(contentManager.Load<Texture2D>("Sprites/WaterTiles/48"), Location, Color.White);
        }
    }
}
