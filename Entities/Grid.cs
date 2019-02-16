﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MBRD.Entities
{
    public abstract class Grid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<List<IPlaceable>> TileSet { get; set; }

        private const int GridSpacing = 1;

        public Grid(int width, int height, int tileSize)
        {
            Width = width;
            Height = height;

            SetupTiles(tileSize);
                        
            Console.WriteLine("Grid create with dimensions {0}x{1}", Width.ToString(), Height.ToString());
        }

        public void SetupTiles(int tileSize)
        {
            TileSet = new List<List<IPlaceable>>();
            for(int y = 0; y < Height; y++)
            {
                List<IPlaceable> row = new List<IPlaceable>();
                for (int x = 0; x < Width; x++)
                {
                    row.Add(new WaterFragment()
                    {
                        Location = new Rectangle(x * (tileSize + GridSpacing), y * (tileSize + GridSpacing), tileSize, tileSize)
                    });
                }

                TileSet.Add(row);
            }
        }

        public void Draw(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            foreach (List<IPlaceable> placeables in TileSet)
            {
                foreach (IPlaceable placeable in placeables)
                {
                    placeable.Draw(contentManager, spriteBatch);
                }
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
