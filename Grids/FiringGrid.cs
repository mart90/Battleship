using System;
using MBRD.Fragments;

namespace MBRD.Grids
{
    public class FiringGrid : AbstractGrid
    {
        public FiringGrid(int width, int height, int tileSize, int horizontalOffset, int verticalOffset) : base(width, height, tileSize, horizontalOffset, verticalOffset)
        {
        }

        public void Fired(int x, int y)
        {
            IFragment target = TileSet[y][x];
            Console.WriteLine("SHOT FIRED ON (x:{0} y:{1})", x.ToString(), y.ToString());

            target.Hit = true;

            if (target is WaterFragment)
            {
                Console.WriteLine("~~~~~~~~ MISS ~~~~~~~~");
            }
            else
            {
                Console.WriteLine("xxxxxxx HIT xxxxxxxxx");
            }
        }
    }
}