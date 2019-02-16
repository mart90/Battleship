using Microsoft.Xna.Framework.Graphics;

namespace MBRD.Entities
{
    public interface IPlaceable
    {
        Texture2D Image { get; set; }
        bool Hit { get; set; }
    }
}
