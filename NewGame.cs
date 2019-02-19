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

        PlayerController playerController;
        GameController gameController;

        private SpriteFont font;
        private readonly ConfigManager config;
        
        private Texture2D startButton;
        private Texture2D exitButton;
        private Texture2D pauseButton;
        private Texture2D resumeButton;
        private Texture2D loadingScreen;

        private Vector2 startButtonPosition;
        private Vector2 exitButtonPosition;
        private Vector2 resumeButtonPosition;
        
        private bool isLoading;
        MouseState mouseState;
        GameState gameState;
        MouseState previousMouseState;
        private List<Player> Players;

        public NewGame()
        {
            config = new ConfigManager("Config.ini");
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = int.Parse(config.Read("Width", "Window")),
                PreferredBackBufferHeight = int.Parse(config.Read("Height", "Window"))
            };
            Content.RootDirectory = "Content";
            Players = new List<Player>();

            graphics.ApplyChanges();

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Components.Add(gameController = new GameController(this));
            Components.Add(playerController = new PlayerController(this));
            
            Services.AddService(typeof(IPlayerService), playerController);
            Services.AddService(typeof(SpriteBatch), spriteBatch);

            //enable the mousepointer
            IsMouseVisible = true;

            //set the gamestate to start menu
            gameState = GameState.StartMenu;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            
            // TODO: use this.Content to load your game content here
            LoadGame();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                gameState = GameState.StartMenu;
            
            mouseState = Mouse.GetState();
            if (previousMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
            {
                MouseClicked(mouseState.X, mouseState.Y);
            }

            previousMouseState = mouseState;

            if (gameState == GameState.Playing && isLoading)
            {
                LoadGame();
                isLoading = false;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            if (gameState == GameState.StartMenu)
            {
                spriteBatch.Draw(startButton, startButtonPosition, Color.White);
                spriteBatch.Draw(exitButton, exitButtonPosition, Color.White);
            }

            if (gameState == GameState.Playing)
            {
                foreach (Player player in playerController.GetPlayers())
                {
                    if (player.IsActive)
                    {
                        player.Draw(Content, spriteBatch);
                        spriteBatch.DrawString(font, player.name.ToString(), new Vector2(700, 10), Color.White);
                    }
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void LoadGame()
        {
            //load the buttonimages into the content pipeline
            startButton = Content.Load<Texture2D>(@"Start_BTN");
            exitButton = Content.Load<Texture2D>(@"Exit_BTN");
            font = Content.Load<SpriteFont>("PlayerName");

            //set the position of the buttons
            startButtonPosition = new Vector2((GraphicsDevice.Viewport.Width / 2) - 205, 100);
            exitButtonPosition = new Vector2((GraphicsDevice.Viewport.Width / 2) - 205, 250);
        }

        protected void MouseClicked(int x, int y)
        {
            //creates a rectangle of 10x10 around the place where the mouse was clicked
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);

            //check the startmenu
            if (gameState == GameState.StartMenu)
            {
                Rectangle startButtonRect = new Rectangle((int)startButtonPosition.X, (int)startButtonPosition.Y, 410, 121);
                Rectangle exitButtonRect = new Rectangle((int)exitButtonPosition.X, (int)exitButtonPosition.Y, 410, 121);

                if (mouseClickRect.Intersects(startButtonRect)) //player clicked start button
                {
                    //gameState = GameState.Loading;
                    gameState = GameState.Playing;
                    isLoading = true;
                }
                else if (mouseClickRect.Intersects(exitButtonRect)) //player clicked exit button
                {
                    Exit();
                }
            }
        }
    }
}
