using COMP3451Project.Managers;
using COMP3451Project.Managers.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;

namespace COMP2451Project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class kernel : Game
    {
        // DECLARES a GraphicsDeviceManager variable called graphics
        GraphicsDeviceManager graphics;
        //DELCARES a SpriteBatch variable called SpriteBatch 
        SpriteBatch spriteBatch;
        // DECLARES a double called ScreenHeight
        public double ScreenHeight;
        // DELCARES a double called ScreenWidth
        public double ScreenWidth;

        // DECLARES a entityManager called entity
        EntityManager entityM;

        //DECLARES a sceneManager called scene
        SceneManager scene;

        //DECLARES a colision manager called colisionM
        ColisionManager colisionM;
        //DELCARES a IEventPublisher called inputM
        IEventPublisher inputM;

        public kernel()
        {
            // INITALIZES a graphic as a New GraphicsDeviceManager passing this as a paramiter
            graphics = new GraphicsDeviceManager(this);
            // Stores the root for the content as Content
            Content.RootDirectory = "Content";
            // Sets the screen height to 900
            graphics.PreferredBackBufferHeight = 900;
            // Sets the screen width to 900
            graphics.PreferredBackBufferWidth = 900;

            // INITALIZES a new entityManager
            entityM = new EntityManager();
            // INTIALZES a new sceneManager
            scene = new SceneManager();

            //INITALIZES a new ColisionManager
            colisionM = new ColisionManager();
            //INTALIZES a new InputManager
            inputM = new InputManager();


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

            //Calss the colision Managers Initalize method passing a reference to the entity list
            colisionM.Initialize(entityM.CreateEntityList());

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

            //DELCARES a new Texture2D variable called temp and loads the square texture
            Texture2D tempTexture = Content.Load<Texture2D>("square");
            //DELCARES a new IEntity called tempEntity
            IEntity tempEntity;
            //INTIALISE a new Vector2 called v
            Vector2 v = new Vector2();
            //Sets the X and Y to 500
            v.X = 500;
            v.Y = 500;

            //INTIALISES tempEntity using the CreateEntity command
            tempEntity = entityM.CreateEntity(3, v, tempTexture);

            // calls the add entity method in scene passing the return value of create ball
            scene.addEntity(tempEntity);

            // loads the paddle texture into temp
            tempTexture = Content.Load<Texture2D>("paddle");

            //Sets the X and Y to 0
            v.X = 0;
            v.Y = 0;
            //INTIALISES tempEntity using the CreateEntity command
            tempEntity = entityM.CreateEntity(1, v, tempTexture);
            //Subscribes the Entity to IInputPubisher
            ((IInputPublisher)inputM).subscribe((IKeyListener)tempEntity);
            //Adds the Entity to the scene
            scene.addEntity(tempEntity);

            //Sets the X to 850 Y to 0
            v.X = 850;
            v.Y = 0;
            //INTIALISES tempEntity using the CreateEntity command
            tempEntity = entityM.CreateEntity(2, v, tempTexture);
            //Subscribes the Entity to IInputPubisher
            ((IInputPublisher)inputM).subscribe((IKeyListener)tempEntity);
            //Adds the Entity to the scene
            scene.addEntity(tempEntity);

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
                Environment.Exit(1);

            // TODO: Add your update logic here

            //Gets the hight of the screen
            ScreenHeight = GraphicsDevice.Viewport.Height;
            //Gets the width or the screen
            ScreenWidth = GraphicsDevice.Viewport.Width;

            ((InputManager)inputM).update();
            // calls the update method in scene passing screen height and width
            scene.update(ScreenHeight , ScreenWidth);

            //Updates the colision manager passing the list 
            colisionM.update();

            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            
            //Begins the Drawing code for spriteBatch
            spriteBatch.Begin();

            //Calls the draw method in scene passing spriteBatch 
            scene.draw(spriteBatch);

            //Ends the Drawing code for SpriteBatch
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
