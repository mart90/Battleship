﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace MegaBattleshipRoyaleDeluxe
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D orb;
        private Texture2D startButton;
        private Texture2D exitButton;
        private Texture2D pauseButton;
        private Texture2D resumeButton;
        private Texture2D loadingScreen;

        private Vector2 orbPosition;
        private Vector2 startButtonPosition;
        private Vector2 exitButtonPosition;
        private Vector2 resumeButtonPosition;

        private const float OrbWidth = 50f;
        private const float OrbHeight = 50f;
        private float speed = 1.5f;

        private Thread backgroundThread;
        private bool isLoading = false;
        MouseState mouseState;
        GameState gameState;
        MouseState previousMouseState;

        const int TargetWidth = 1920;
        const int TargetHeight = 1080;
        
        enum GameState
        {
            StartMenu,
            Loading,
            Playing,
            Paused
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = TargetWidth;
            graphics.PreferredBackBufferHeight = TargetHeight;
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

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

            // TODO: Add your update logic here
            orbPosition.X += speed;

            if (orbPosition.X > (GraphicsDevice.Viewport.Width - OrbWidth) || orbPosition.X < 0)
            {
                speed *= -1;
            }

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
                spriteBatch.Draw(orb, orbPosition, Color.White);
            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void LoadGame()
        {
            //load the game images into the content pipeline
            orb = Content.Load<Texture2D>(@"ball");
            orbPosition = new Vector2((GraphicsDevice.Viewport.Width / 2) - (OrbWidth / 2), (GraphicsDevice.Viewport.Height / 2) - (OrbHeight / 2));

            //load the buttonimages into the content pipeline
            startButton = Content.Load<Texture2D>(@"Start_BTN");
            exitButton = Content.Load<Texture2D>(@"Exit_BTN");

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
