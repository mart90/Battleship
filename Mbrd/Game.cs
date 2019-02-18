using System.Collections.Generic;
using System.Diagnostics;
using MBRD.Boats.Factory;

namespace MBRD
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
            Players[0].boatGrid.Hit(x, y);

            ShowFiringGrid(Players[0]);
            //ShowBoatGrid(Players[0]);
        }

        public void ShowFiringGrid(Player Player)
        {
            Debug.WriteLine("[" + Player.name + " - FiringGrid]");
            Debug.WriteLine("----------");
            for (int x = 0; x < Player.firingGrid.Height; x++)
            {
                for (int y = 0; y < Player.firingGrid.Width; y++)
                {
                    if (y == Player.firingGrid.Width - 1)
                    {
                        if (Player.firingGrid.TileSet[y][x].Hit)
                        {
                            Debug.WriteLine("H ");
                        }
                        else
                        {
                            Debug.WriteLine("W ");
                        }

                    }
                    else
                    {
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

        public void ShowBoatGrid(Player player)
        {
            Debug.WriteLine("[" + player.name + " - BoatGrid]");
            Debug.WriteLine("----------");
            for (int x = 0; x < player.boatGrid.Height; x++)
            {
                for (int y = 0; y < player.boatGrid.Width; y++)
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
