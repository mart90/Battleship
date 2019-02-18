using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBRD.Component
{
    interface IPlayerService
    {
        void CreatePlayer(string name, Color color, int order = 1, bool active = true);
        Player GetActive();
        List<Player> GetPlayers();
    }

    class PlayerController : GameComponent, IPlayerService
    {
        Game game;
        List<Player> players;

        public PlayerController(Game game) : base(game)
        {
            this.game = game;
            players = new List<Player>();
        }

        public override void Initialize()
        {
            CreatePlayer("Player 1", Color.Blue, 1, true);
            CreatePlayer("Player 2", Color.Blue, 1, false);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void CreatePlayer(string name, Color color, int order = 1, bool active = true)
        {
            players.Add(new Player(name, color, order, active));
        }

        public Player GetActive()
        {
            foreach (Player player in players)
            {
                if (player.IsActive)
                    return player;
            }

            return null;
        }

        public List<Player> GetPlayers()
        {
            return players;
        }
    }
}
