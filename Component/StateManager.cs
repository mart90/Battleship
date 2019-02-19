using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MBRD.Component
{
    class StateManager : GameComponent, IStateService
    {
        Game game;
        GameState GameState;

        public StateManager(Game game) : base(game)
        {
            this.game = game;
        }

        public override void Initialize()
        {
            ChangeState(GameState.StartMenu);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                if (GetCurrentState() == GameState.Playing) {
                    ChangeState(GameState.StartMenu);
                }
            }
            
            base.Update(gameTime);
        }

        public void ChangeState(GameState newState)
        {
            GameState = newState;
        }

        public GameState GetCurrentState()
        {
            return GameState;
        }
    }
}
