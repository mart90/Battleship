using Microsoft.Xna.Framework;

namespace MBRD.Entities
{
    class IconSpriteRectangleFactory
    {
        public static Rectangle GetRectangle(int column, int row)
        {
            return new Rectangle(column * 32, row * 32, 32, 32);
        }
    }
}
