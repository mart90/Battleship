using Microsoft.Xna.Framework.Graphics;

namespace MBRD.Entities
{
    class WaterFragment : IPlaceable
    {
        public Texture2D Image { get; set; }
        public bool Hit { get; set; }
    }
}
