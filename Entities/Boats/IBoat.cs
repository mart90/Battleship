using Microsoft.Xna.Framework.Graphics;

namespace MBRD.Entities
{
    public interface IBoat
    {
        int Length { get; set; }
        string FrontImage { get; set; }
        string MidImage { get; set; }
        string BackImage { get; set; }

        void Hit();
    }
}
