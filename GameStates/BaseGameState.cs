using Microsoft.Xna.Framework;
using System;

namespace MBRD.GameStates
{
    public class BaseGameState : GameState
    {
        protected static Random random = new Random();

        protected NewGame GameRef;

        public BaseGameState(Game game) : base(game)
        {
            GameRef = (NewGame)game;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
