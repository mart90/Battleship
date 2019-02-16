namespace MBRD.Entities
{
    class BoatFactory
    {
        public T GenerateBoat<T>(int length, string frontImage, string midImage, string backImage) where T : new()
        {
            var boat = (IBoat)new T();
            boat.Length = length;
            boat.FrontImage = frontImage;
            boat.MidImage = midImage;
            boat.BackImage = backImage;

            return (T)boat;
        }

        public AircraftCarrier GenerateDefaultAircraftCarrier()
        {
            return GenerateBoat<AircraftCarrier>(5, "BoatTile-Front.png", "BoatTile-Middle.png", "BoatTile-Back.png");
        }

        public Battleship GenerateDefaultBattleship()
        {
            return GenerateBoat<Battleship>(4, "BoatTile-Front.png", "BoatTile-Middle.png", "BoatTile-Back.png");
        }

        public Submarine GenerateDefaultSubmarine()
        {
            return GenerateBoat<Submarine>(3, "BoatTile-Front.png", "BoatTile-Middle.png", "BoatTile-Back.png");
        }

        public Scout GenerateDefaultScout()
        {
            return GenerateBoat<Scout>(2, "BoatTile-Front.png", null, "BoatTile-Back.png");
        }
    }
}
