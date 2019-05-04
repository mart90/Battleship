﻿using System;

namespace MBRD.Boats.Factory
{
    public class BoatFactory
    {
        public static T GenerateBoat<T>(int length, string frontImage, string midImage, string backImage) where T : new()
        {
            var boat = (IBoat)new T();
            boat.Length = length;
            boat.FrontImage = frontImage;
            boat.MidImage = midImage;
            boat.BackImage = backImage;

            Console.WriteLine("Generate Boat: {0}", boat);
            return (T)boat;
        }

        public static AircraftCarrier GenerateDefaultAircraftCarrier()
        {
            return GenerateBoat<AircraftCarrier>(5, "BoatTile-Front.png", "BoatTile-Middle.png", "BoatTile-Back.png");
        }

        public static Battleship GenerateDefaultBattleship()
        {
            return GenerateBoat<Battleship>(4, "BoatTile-Front.png", "BoatTile-Middle.png", "BoatTile-Back.png");
        }

        public static Submarine GenerateDefaultSubmarine()
        {
            return GenerateBoat<Submarine>(3, "BoatTile-Front.png", "BoatTile-Middle.png", "BoatTile-Back.png");
        }

        public static Scout GenerateDefaultScout()
        {
            return GenerateBoat<Scout>(2, "BoatTile-Front.png", null, "BoatTile-Back.png");
        }
    }
}
