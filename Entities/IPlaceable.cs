using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MBRD.Entities
{
    public interface IPlaceable
    {
        Rectangle Location { get; set; }
        bool Hit { get; set; }

        void Draw(ContentManager contentManager, SpriteBatch spriteBatch);
    }
}
