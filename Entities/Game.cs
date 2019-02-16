using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBRD.Entities
{
    class MBRDGame
    {
        public List<Player> Players;

        public MBRDGame()
        {
            Players = new List<Player>();
        }
        
        /// <summary>
        /// Add a player to the game
        /// </summary>
        /// <param name="Player"></param>
        public void AddPlayer(Player Player)
        {
            Players.Add(Player);
        }
        
        /// <summary>
        /// Setup game starting position, generate player fleet
        /// </summary>
        public void Initialize()
        {
            GenerateFleet();
        }
        
        private void GenerateFleet()
        {
            FleetFactory FleetFactory = new FleetFactory();

            foreach (Player Player in Players)
            {
                Player.AddFleet(FleetFactory.GenerateFleet());
            }
        }

        public void Hit(int x, int y)
        {
            Players[0].BoatGrid.Hit(x, y);

            ShowFiringGrid(Players[0]);
            //ShowBoatGrid(Players[0]);
        }

        public void ShowFiringGrid(Player Player)
        {
            Debug.WriteLine("[" + Player.Name + " - FiringGrid]");
            Debug.WriteLine("----------");
            for (int x = 0; x < Player.FiringGrid.Height; x++)
            {
                for (int y = 0; y < Player.FiringGrid.Width; y++)
                {
                    if(y == Player.FiringGrid.Width - 1)
                    {
                        if (Player.FiringGrid.TileSet[y][x].Hit)
                        {
                            Debug.WriteLine("H ");
                        } else {
                            Debug.WriteLine("W ");
                        }
                        
                    } else {
                        if (Player.FiringGrid.TileSet[y][x].Hit)
                        {
                            Debug.Write("H ");
                        }
                        else
                        {
                            Debug.Write("W ");
                        }
                        
                    }
                    
                }
            }
        }

        public void ShowBoatGrid(Player player)
        {
            Debug.WriteLine("[" + player.Name + " - BoatGrid]");
            Debug.WriteLine("----------");
            for (int x = 0; x < player.BoatGrid.Height; x++)
            {
                for (int y = 0; y < player.BoatGrid.Width; y++)
                {
                    if (y == player.BoatGrid.Width - 1)
                    {
                        if (player.BoatGrid.TileSet[y][x].Hit)
                        {
                            Debug.WriteLine("X ");
                        }
                        else
                        {
                            Debug.WriteLine("~ ");
                        }

                    }
                    else
                    {
                        if (player.BoatGrid.TileSet[y][x].Hit)
                        {
                            Debug.Write("X ");
                        }
                        else
                        {
                            Debug.Write("~ ");
                        }

                    }

                }
            }
        }
    }
}
