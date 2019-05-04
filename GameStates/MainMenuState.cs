using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBRD.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MBRD.GameStates
{
    public interface IMainMenuState : IGameState
    {
    }

    public class MainMenuState : BaseGameState, IMainMenuState
    {
        Texture2D background;
        SpriteFont spriteFont;
        MenuComponent menuComponent;
        Rectangle backgroundDestination;

        public MainMenuState(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IMainMenuState), this);
        }

        public override void Initialize()
        {
            backgroundDestination = NewGame.ScreenRectangle;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteFont = Game.Content.Load<SpriteFont>(@"Fonts\InterfaceFont");
            background = Game.Content.Load<Texture2D>(@"GameScreens\TitleScreenPirate");

            Texture2D texture = Game.Content.Load<Texture2D>("wooden-button");

            string[] menuItems = { "NEW GAME", "CONTINUE", "OPTIONS", "EXIT" };

            menuComponent = new MenuComponent(spriteFont, texture, menuItems);

            Vector2 position = new Vector2
            {
                Y = 90,
                X = 1200 - menuComponent.Width
            };

            menuComponent.Postion = position;

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            menuComponent.Update(gameTime);

            if (InputComponent.CheckKeyReleased(Keys.Space) || InputComponent.CheckKeyReleased(Keys.Enter) || (menuComponent.MouseOver && InputComponent.CheckMouseReleased(MouseButtons.Left)))
            {
                if (menuComponent.SelectedIndex == 0)
                {
                    InputComponent.FlushInput();
                    GameRef.GamePlayState.SetUpNewGame();
                    GameRef.GamePlayState.StartGame();
                    manager.PushState((GameSetupState)GameRef.GamePlayState, PlayerIndexInControl);
                }
                else if (menuComponent.SelectedIndex == 1)
                {
                    InputComponent.FlushInput();
                    GameRef.GamePlayState.LoadExistingGame();
                    GameRef.GamePlayState.StartGame();
                    manager.PushState((GameSetupState)GameRef.GamePlayState, PlayerIndexInControl);
                }
                else if (menuComponent.SelectedIndex == 2)
                {
                    InputComponent.FlushInput();
                }
                else if (menuComponent.SelectedIndex == 3)
                {
                    Game.Exit();
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            GameRef.SpriteBatch.Draw(background, backgroundDestination, Color.White);

            GameRef.SpriteBatch.End();

            base.Draw(gameTime);

            GameRef.SpriteBatch.Begin();

            menuComponent.Draw(gameTime, GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();

        }

    }
}
