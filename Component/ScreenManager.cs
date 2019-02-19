using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBRD.Component
{
    class ScreenManager : DrawableGameComponent
    {
        Game game;
        StateManager StateManager;
        PlayerManager PlayerManager;
        SpriteBatch spriteBatch;

        private SpriteFont font;

        private Texture2D startButton;
        private Texture2D exitButton;

        private Vector2 startButtonPosition;
        private Vector2 exitButtonPosition;

        MouseState mouseState;
        MouseState previousMouseState;

        public ScreenManager(Game game) : base(game)
        {
            this.game = game;
        }

        public override void Initialize()
        {
            spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            StateManager = (StateManager)game.Services.GetService(typeof(IStateService));
            PlayerManager = (PlayerManager)game.Services.GetService(typeof(IPlayerService));

            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);
            this.spriteBatch.Begin();

            if (this.StateManager.GetCurrentState() == GameState.StartMenu)
            {
                spriteBatch.Draw(startButton, startButtonPosition, Color.White);
                spriteBatch.Draw(exitButton, exitButtonPosition, Color.White);
            }

            if (StateManager.GetCurrentState() == GameState.Playing)
            {
                foreach (Player player in PlayerManager.GetPlayers())
                {
                    if (player.IsActive)
                    {
                        player.Draw(game.Content, spriteBatch);
                        spriteBatch.DrawString(font, player.name.ToString(), new Vector2(700, 10), Color.White);
                    }
                }
            }

            spriteBatch.End();
        }

        protected override void LoadContent()
        {
            //load the buttonimages into the content pipeline
            startButton = Game.Content.Load<Texture2D>(@"Start_BTN");
            exitButton = Game.Content.Load<Texture2D>(@"Exit_BTN");
            font = Game.Content.Load<SpriteFont>("PlayerName");

            //set the position of the buttons
            startButtonPosition = new Vector2((Game.GraphicsDevice.Viewport.Width / 2) - 205, 100);
            exitButtonPosition = new Vector2((Game.GraphicsDevice.Viewport.Width / 2) - 205, 250);
        }

        public override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
            {
                MouseClicked(mouseState.X, mouseState.Y);
            }

            previousMouseState = mouseState;

            base.Update(gameTime);
        }

        protected void MouseClicked(int x, int y)
        {
            //creates a rectangle of 10x10 around the place where the mouse was clicked
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);

            //check the startmenu
            if (StateManager.GetCurrentState() == GameState.StartMenu)
            {
                Rectangle startButtonRect = new Rectangle((int)startButtonPosition.X, (int)startButtonPosition.Y, 410, 121);
                Rectangle exitButtonRect = new Rectangle((int)exitButtonPosition.X, (int)exitButtonPosition.Y, 410, 121);

                if (mouseClickRect.Intersects(startButtonRect)) //player clicked start button
                {
                    StateManager.ChangeState(GameState.Playing);
                }
                else if (mouseClickRect.Intersects(exitButtonRect)) //player clicked exit button
                {
                    game.Exit();
                }
            }
        }
    }
}
