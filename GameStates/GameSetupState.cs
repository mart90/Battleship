﻿using MBRD.Boats.Factory;
using MBRD.Components;
using MBRD.TileEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MBRD.GameStates
{
    public interface IGameSetupState
    {
        void SetUpNewGame();

        void LoadExistingGame();

        void StartGame();
    }

    public class GameSetupState : BaseGameState, IGameSetupState
    {
        Engine engine = new Engine(NewGame.ScreenRectangle, 32, 32);
        SpriteFont spriteFont;

        public GameSetupState(Game game)
        : base(game)
        {
            game.Services.AddService(typeof(IGameSetupState), this);
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

            
        }

        public void SetUpNewGame()
        {
            Texture2D SeaTiles = GameRef.Content.Load<Texture2D>(@"sea-sprite");
            TileSet SeaSet = new TileSet(16, 16, 32, 32)
            {
                Texture = SeaTiles
            };

            Texture2D BoatTiles = GameRef.Content.Load<Texture2D>(@"sprites/iets");
            TileSet BoatSet = new TileSet(16, 16, 32, 32)
            {
                Texture = BoatTiles
            };

            CreatePlayer("Player 1", Color.Blue, SeaSet, BoatSet, 1, true);
            CreatePlayer("Player 2", Color.Red, SeaSet, BoatSet, 2, false);

            PlayerIndexInControl = PlayerIndex.One;

        }

        public void LoadExistingGame()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
        }

        public void CreatePlayer(string name, Color color, TileSet SeaSet, TileSet BoatSet, int order = 1, bool active = true)
        {
            var player = new Player(name, color, order, active, SeaSet, BoatSet);
            player.AddFleet(FleetFactory.GenerateFleet());

            GameRef.players.Add(player);
        }
    }

}
