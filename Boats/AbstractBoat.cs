using MBRD.Fragments;
using MBRD.TileEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace MBRD.Boats
{
    public abstract class AbstractBoat : IBoat
    {
        protected List<BoatFragment> boatFragmentList;

        public int Length { get; set; }
        public string FrontImage { get; set; }
        public string MidImage { get; set; }
        public string BackImage { get; set; }

        public AbstractBoat()
        {
            boatFragmentList = new List<BoatFragment>();
        }

        public void Create()
        {
             for (int y = 0; y < Length; y++)
             {
                boatFragmentList.Add(new BoatFragment());
             }
        }

        public void Hit()
        {
            throw new System.NotImplementedException();
        }

        //public void Draw(SpriteBatch spriteBatch, TileSet tileSet)
        //{
        //    spriteBatch.Begin();

        //    spriteBatch.Draw(
        //        tileSet.Texture, //texture
        //        destination, //rect
        //        tileSet.SourceRectangles[tile],//rect
        //        Color.White //color
        //    );

        //    spriteBatch.End();
        //}
        
    }
}
