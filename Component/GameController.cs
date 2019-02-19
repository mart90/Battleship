using MBRD.Boats.Factory;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MBRD.Component
{
    class GameController : GameComponent
    {
        Game game;
        FleetFactory FleetFactory = new FleetFactory();

        public GameController(Game game) : base(game)
        {
            this.game = game;            
        }

        public override void Initialize()
        {
            PlayerManager playerController = (PlayerManager)game.Services.GetService(typeof(IPlayerService));

            foreach (Player Player in playerController.GetPlayers())
            {
                Player.AddFleet(FleetFactory.GenerateFleet());
            }

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected void changeTurn()
        {

        }
    }
}
