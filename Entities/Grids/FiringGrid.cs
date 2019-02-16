using System;

namespace MBRD.Entities
{
    class FiringGrid : Grid
    {
        public FiringGrid(int width, int height, int tileSize, int horizontalOffset, int verticalOffset) : base(width, height, tileSize, horizontalOffset, verticalOffset)
        {
        }

        public void Fired(int x, int y)
        {
            IPlaceable target = TileSet[y][x];
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