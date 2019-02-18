using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBRD.Boats
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
