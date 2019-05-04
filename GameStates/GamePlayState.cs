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
        Engine engine = new Engine(NewGame.ScreenRectangle, 32, 32);
        TileMap BoatMap;
        TileMap FiringMap;
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

            if (BoatMap != null)
                BoatMap.Draw(gameTime, GameRef.SpriteBatch);

            if (FiringMap != null)
                FiringMap.Draw(gameTime, GameRef.SpriteBatch);
        }

        public void SetUpNewGame()
        {
            CreatePlayer("Player 1", Color.Blue, 1, true);
            CreatePlayer("Player 2", Color.Blue, 2, false);

            Texture2D Tiles = GameRef.Content.Load<Texture2D>(@"sea-sprite");
            TileSet Set = new TileSet(16, 16, 32, 32)
            {
                Texture = Tiles
            };
                       
            //Boat stuff
            TileLayer SeaLayer = new TileLayer(100, 100, 22);
            TileLayer BoatLayer = new TileLayer(100, 100, -1);
            
            BoatMap = new TileMap(Set, SeaLayer, BoatLayer, "player-boat-map");

            //fire stuff
            TileLayer FiringLayer = new TileLayer(100, 100, 22, 350);
            TileLayer ShotMarkingLayer = new TileLayer(100, 100, 4, 350);
            FiringMap = new TileMap(Set, FiringLayer, ShotMarkingLayer, "player-firing-map");
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
