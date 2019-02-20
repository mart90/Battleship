using MBRD.Components;
using MBRD.TileEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MBRD.GameStates
{
    public interface IGamePlayState
    {
        void SetUpNewGame();

        void LoadExistingGame();

        void StartGame();
    }

    public class GamePlayState : BaseGameState, IGamePlayState
    {
        Engine engine = new Engine(NewGame.ScreenRectangle, 64, 64);
        TileMap map;
        List<Player> players = new List<Player>();
        SpriteFont spriteFont;

        public GamePlayState(Game game)
        : base(game)
        {
            game.Services.AddService(typeof(IGamePlayState), this);
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteFont = Game.Content.Load<SpriteFont>(@"Fonts\InterfaceFont");
        }
        public override void Update(GameTime gameTime)
        {
            if (InputComponent.CheckKeyReleased(Keys.Escape))
            {
                InputComponent.FlushInput();
                manager.ChangeState((MainMenuState)GameRef.StartMenuState, PlayerIndexInControl);
            }
                
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GameRef.GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);

            if (map != null)
                map.Draw(gameTime, GameRef.SpriteBatch);
        }

        public void SetUpNewGame()
        {
            CreatePlayer("Player 1", Color.Blue, 1, true);
            CreatePlayer("Player 2", Color.Blue, 2, false);

            //Texture2D tiles = GameRef.Content.Load<Texture2D>(@"Sprites\WaterTiles\48");
            Texture2D tiles = GameRef.Content.Load<Texture2D>(@"sea-sprite");
            TileSet set = new TileSet(16, 12, 32, 32);
            set.Texture = tiles;
            TileLayer sea = new TileLayer(100, 100, 22);
            TileLayer boat = new TileLayer(100, 100, -1);
            
            map = new TileMap(set, sea, boat, "player-map");
        }

        public void LoadExistingGame()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
        }

        public void CreatePlayer(string name, Color color, int order = 1, bool active = true)
        {
            players.Add(new Player(name, color, order, active));
        }
    }

}
