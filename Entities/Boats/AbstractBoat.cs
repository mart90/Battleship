using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MBRD.Entities
{
    abstract class AbstractBoat : IBoat
    {
        protected List<BoatFragment> _boatFragmentList;

        public int Length { get; set; }
        public string FrontImage { get; set; }
        public string MidImage { get; set; }
        public string BackImage { get; set; }

        public AbstractBoat()
        {
            _boatFragmentList = new List<BoatFragment>();
        }

        public void Create()
        {
             for (int y = 0; y < Length; y++)
             {
                _boatFragmentList.Add(new BoatFragment());
             }
        }

        public void Hit()
        {
            throw new System.NotImplementedException();
        }
    }
}
