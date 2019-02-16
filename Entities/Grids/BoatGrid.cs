﻿using System;

namespace MBRD.Entities
{
    class BoatGrid : Grid
    {
        public BoatGrid(int width, int height, int tileSize) : base(width, height, tileSize)
        {
        }

        public void Hit(int x, int y)
        {
            IPlaceable target = TileSet[y][x];
            Console.WriteLine("SHOT FIRED ON (x:{0} y:{1})", x.ToString(), y.ToString());

            target.Hit = true;

            if (target is BoatFragment)
            {
                Console.WriteLine("xxxxxxx HIT xxxxxxxxx");
            }
            else
            {
                Console.WriteLine("~~~~~~~~ MISS ~~~~~~~~");
            }
        }
    }
}
