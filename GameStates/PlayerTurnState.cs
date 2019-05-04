using MBRD.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MBRD.GameStates
{
    public interface IPlayerTurnState : IGameState
    {

    }

    public class PlayerTurnState : BaseGameState, IPlayerTurnState
    {
        public PlayerTurnState(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IPlayerTurnState), this);
        }

        public override void Update(GameTime gameTime)
        {
            if (InputComponent.CheckKeyReleased(Keys.NumPad0))
            {
                if (PlayerIndexInControl == PlayerIndex.One)
                    PlayerIndexInControl = PlayerIndex.Two;
                else
                    PlayerIndexInControl = PlayerIndex.One;

                Console.WriteLine("Change turn to player : {0}", PlayerIndexInControl);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.GraphicsDevice.Clear(Color.Black);

            var CurrentPlayer = (int) PlayerIndexInControl.Value;

            if (GameRef.players[CurrentPlayer].boatGrid != null)
                GameRef.players[CurrentPlayer].boatGrid.Draw(gameTime, GameRef.SpriteBatch);

            if (GameRef.players[CurrentPlayer].firingGrid != null)
                GameRef.players[CurrentPlayer].firingGrid.Draw(gameTime, GameRef.SpriteBatch);
            base.Draw(gameTime);
        }
    }
    
}
