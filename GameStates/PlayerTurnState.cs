using MBRD.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        public override void Draw(GameTime gameTime)
        {
            GameRef.GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);

            if (GameRef.players[0].boatGrid != null)
                GameRef.players[0].boatGrid.Draw(gameTime, GameRef.SpriteBatch);

            if (GameRef.players[0].firingGrid != null)
                GameRef.players[0].firingGrid.Draw(gameTime, GameRef.SpriteBatch);
        }
    }
    
}
