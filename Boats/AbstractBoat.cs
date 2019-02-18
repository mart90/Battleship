using MBRD.Fragments;
using System.Collections.Generic;


namespace MBRD.Boats
{
    abstract class AbstractBoat : IBoat
    {
        protected List<BoatFragment> boatFragmentList;

        public int length { get; set; }
        public string frontImage { get; set; }
        public string midImage { get; set; }
        public string backImage { get; set; }

        public AbstractBoat()
        {
            boatFragmentList = new List<BoatFragment>();
        }

        public void Create()
        {
             for (int y = 0; y < length; y++)
             {
                boatFragmentList.Add(new BoatFragment());
             }
        }

        public void Hit()
        {
            throw new System.NotImplementedException();
        }
        
    }
}
