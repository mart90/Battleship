﻿using System;
using MBRD.Fragments;

namespace MBRD.Grids
{
    class BoatGrid : AbstractGrid
    {
        public BoatGrid(int width, int height, int tileSize, int horizontalOffset, int verticalOffset) : base(width, height, tileSize, horizontalOffset, verticalOffset)
        {
        }

        public void Hit(int x, int y)
        {
            IFragment target = TileSet[y][x];
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
