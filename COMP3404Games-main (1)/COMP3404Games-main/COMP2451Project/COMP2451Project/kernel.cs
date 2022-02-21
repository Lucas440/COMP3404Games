using Engine.Factories;
using Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// AUTHOR: Lucas Brennan
/// CO-AUTHOR: William Eardley, Flynn Osbourne
/// DATE: 07/02/2022
/// </summary>

namespace Engine
{
    /// <summary>
    /// CLASS 'Kernel' - Main class for the engine - inherits from 'Game'
    /// </summary>
    public class kernel : Game
    {
        // DECLARE a GraphicsDeviceManager variable called graphics
        private GraphicsDeviceManager graphics;

        // DELCARE a SpriteBatch variable called SpriteBatch 
        private SpriteBatch spriteBatch;

        // DECLARE a double called ScreenHeight
        private double ScreenHeight;

        // DELCARE a double called ScreenWidth
        private double ScreenWidth;

        // DECLARE private variable '_engineManager' as type EngineManager
        private EngineManager _engineManager;

        // DECLARE a factory locator named _factories
        IFactoryLocator _factories;

        /// <summary>
        /// CONSTRUCTOR 'Kernel' - called upon Instantiation
        /// </summary>
        /// <param name="pengineManager"></param>
        public kernel(EngineManager pengineManager)
        {
            // INITALIZES a graphic as a New GraphicsDeviceManager passing this as a paramiter
            graphics = new GraphicsDeviceManager(this);

            // Stores the root for the content as Content
            Content.RootDirectory = "Content";

            // Sets the screen height to 900
            graphics.PreferredBackBufferHeight = 900;

            // Sets the screen width to 900
            graphics.PreferredBackBufferWidth = 900;

            // SET _engineManager to the parameter value passed from Program
            _engineManager = pengineManager;

            // INSTANTIATE '_factories' as new FactoryLocator
            _factories = new FactoryLocator();
        }

        /// <summary>
        /// METHOD 'Initialise' 
        /// 
        /// PURPOSE: Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Creates a new spriteFont and loads a default text font into it
            SpriteFont spriteFont = Content.Load<SpriteFont>("Text");
            // CALL Initialise method inside EngineManager - Passes the spriteFont
            _engineManager.Initialise(spriteFont);

            // CALL Initiaise method inside base class
            base.Initialize();
        }

        /// <summary>
        /// METHOD 'LoadContent'
        /// 
        /// PURPOSE: LoadContent will be called once per game and is the place to load all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // INSTANTIATE spriteBatch as new SpriteBatch
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // CALL LoadContent method inside EngineManager
            _engineManager.LoadContent(Content);
        }


        /// <summary>
        /// METHOD 'UnloadContent'
        /// 
        /// PURPOSE: UnloadContent will be called once per game and is the place to unload
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
            // IF back button on gamepad or escape key is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                // CALL 'Exit' method
                Exit();
            }

            // SET ScreenHeight to viewport height - height of the screen
            ScreenHeight = GraphicsDevice.Viewport.Height;

            // SET ScreenWidth to viewport width - width of the screen
            ScreenWidth = GraphicsDevice.Viewport.Width;

            // CALL 'Update' method inside EngineManager - passing screen width and height
            _engineManager.Update(ScreenHeight, ScreenWidth);

            // CALL Update in base class
            base.Update(gameTime);
        }

        /// <summary>
        /// METHOD 'Draw'
        /// PURPOSE: This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // CALL 'Clear' method inside GraphicsDevice
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // CALL 'Begin' method for spriteBatch
            spriteBatch.Begin();

            // CALL 'Draw' method inside EngineManager class - passing spriteBatch
            _engineManager.Draw(spriteBatch);

            // CALL 'End' method for spriteBatch
            spriteBatch.End();

            // CALL 'Draw' method for base class - passes game time
            base.Draw(gameTime);
        }
    }
}
