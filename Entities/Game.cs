using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBRD.Entities
{
    class Game
    {
        private List<Player> Players;

        public Game()
        {
            Players = new List<Player>();
        }

        public void Launch()
        {
            Setup();
            Start();
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
        private void Setup()
        {
            GenerateFleet();
        }

        private void Start()
        {
            Debug.WriteLine("PLAYER 1 START!");
            ShowFiringGrid(Players[0]);
            ShowBoatGrid(Players[0]);
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
            Players[0].boatGrid.Hit(x, y);

            ShowFiringGrid(Players[0]);
            ShowBoatGrid(Players[0]);
        }

        private void ShowFiringGrid(Player Player)
        {
            Debug.WriteLine("[" + Player.name + " - FiringGrid]");
            Debug.WriteLine("----------");
            for (int x = 0; x < Player.firingGrid.Height; x++)
            {
                for (int y = 0; y < Player.firingGrid.Width; y++)
                {
                    if(y == Player.firingGrid.Width - 1)
                    {
                        if (Player.firingGrid.TileSet[y][x].Hit)
                        {
                            Debug.WriteLine("H ");
                        } else {
                            Debug.WriteLine("W ");
                        }
                        
                    } else {
                        if (Player.firingGrid.TileSet[y][x].Hit)
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

        private void ShowBoatGrid(Player player)
        {
            Debug.WriteLine("[" + player.name + " - BoatGrid]");
            Debug.WriteLine("----------");
            for (int x = 0; x < player.boatGrid.Height; x++)
            {
                for (int y = 0; y < player.firingGrid.Width; y++)
                {
                    if (y == player.boatGrid.Width - 1)
                    {
                        if (player.boatGrid.TileSet[y][x].Hit)
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
                        if (player.boatGrid.TileSet[y][x].Hit)
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
