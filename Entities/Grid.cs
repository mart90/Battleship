using System;
using System.Collections.Generic;

namespace MBRD.Entities
{
    public abstract class Grid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<List<IPlaceable>> TileSet { get; set; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
                        
            Console.WriteLine("Firinggrid create with dimensions {0}x{1}", Width.ToString(), Height.ToString());
            Create();
        }

        private void Create()
        {
            TileSet = new List<List<IPlaceable>>();
            for(int y = 0; y < Height; y++)
            {
                List<IPlaceable> row = new List<IPlaceable>();
                for (int x = 0; x < Width; x++)
                {
                    row.Add(new BoatFragment());
                }

                TileSet.Add(row);
            }
        }

        private bool DoesItFit(AbstractBoat boat, List<Tuple<int, int>> fragments)
        {
            //Hier iets doen!

            return true;
        }

        private bool DoesItFit(AbstractBoat boat, int startX, int startY, bool horizontal)
        {
            if (horizontal)
            {
                //Past de boot hier uberhaupt?
                if (!((startX + boat.length) <= Width))
                    return false;

                //Door alle grid-items loopen en kijken of er een boot ligt
                for (int i = startX; i < (startX + boat.length); i++)
                {
                    if (TileSet[startY][i] is BoatFragment)
                    {
                        return false;
                    }
                }

                return true;
            } else
            {
                //Past de boot hier uberhaupt?
                if (!((startY + boat.length) <= Height))
                    return false;

                //Door alle grid-items loopen en kijken of er een boot ligt
                for (int i = startY; i < (startY + boat.length); i++)
                {
                    if (TileSet[i][startX] is BoatFragment)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
