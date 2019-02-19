using MBRD.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using MBRD.Boats.Factory;

namespace MBRD
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class NewGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        PlayerManager playerController;
        GameController gameController;
        StateManager stateManager;
        ScreenManager screenManager;

        private readonly ConfigManager config;
        
        public NewGame()
        {
            config = new ConfigManager("Config.ini");
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = int.Parse(config.Read("Width", "Window")),
                PreferredBackBufferHeight = int.Parse(config.Read("Height", "Window"))
            };
            Content.RootDirectory = "Content";

            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Components.Add(gameController = new GameController(this));
            Components.Add(playerController = new PlayerManager(this));
            Components.Add(stateManager = new StateManager(this));
            Components.Add(screenManager = new ScreenManager(this));

            Services.AddService(typeof(IStateService), stateManager);
            Services.AddService(typeof(IPlayerService), playerController);
            Services.AddService(typeof(SpriteBatch), spriteBatch);

            //enable the mousepointer
            IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    }
}
