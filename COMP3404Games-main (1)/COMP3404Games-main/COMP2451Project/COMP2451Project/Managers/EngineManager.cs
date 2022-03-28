using COMP3451Project.Managers;
using DrVsVirusGame.GameEntities;
using Engine.Command;
using Engine.EngineEntitys;
using Engine.Factories;
using Engine.InputEvents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PongGame.Entities;
using System;

/// <summary>
/// CLASS: 'EngineManager' - manages game engine
/// AUTHOR: Will Eardley
/// MODIFIED BY: Flynn Osborne
/// DATE: 21/03/22
/// </summary>
namespace Engine.Managers
{
    public class EngineManager
    {
        // DECLARE private variable '_entityManager' as type EntityManager
        private EntityManager _entityManager;

        // DECLARE private variable '_sceneManager' as type SceneManager
        private SceneManager _sceneManager;

        // DECLARE private variable '_collisionManager' as type CollisionManager
        private ColisionManager _collisionManager;

        // DECLARE private variable '_factoryLocator' as type IFactoryLocater
        private IFactoryLocator _factoryLocator;

        // DECLARE a private variable calld_inputManager as IEventPublisher
        private IEventPublisher _inputManager;

        //DCLARE a private variable called _commandScheduler as ICommandScheduler
        private ICommandScheduler _commandScheduler;

        //DECLARE two Doubles _height and _width
        double _height, _width;

        // DECLARE two arrays to contain the grid
        int[] _gridX;
        int[] _gridY;

        // DECLARE two variables to hold the number of rows and columns in the grid
        int _gridXLength, _gridYLength;

        /// <summary>
        /// CONSTRUCTOR for EngineManager
        /// </summary>
        public EngineManager(IFactoryLocator pfactoryLocator)
        {
            // SET _factoryLocator to pfactoryLocator parameter
            _factoryLocator = pfactoryLocator;

            //INTALISES _inputManager
            _inputManager = (_factoryLocator.Get<IEventPublisher>() as IFactory<IEventPublisher>).Create<InputManager>();

            // INSTANTIATE '_sceneManager' as new SceneManager
            _sceneManager = (_factoryLocator.Get<SceneManager>() as IFactory<SceneManager>).Create<SceneManager>();

            // INSTANTIATE '_collisionManager' as new CollisionManager
            _collisionManager = (_factoryLocator.Get<ColisionManager>() as IFactory<ColisionManager>).Create<ColisionManager>();

            // INSTANTIATE '_entityManager' as new EntityManager
            _entityManager = (_factoryLocator.Get<EntityManager>() as IFactory<EntityManager>).Create<EntityManager>();
            //INSTANTIATE _commandScheduler as new CommandSchedular
            _commandScheduler = (_factoryLocator.Get<ICommandScheduler>() as IFactory<ICommandScheduler>).Create<CommandScheduler>();

            // Set the amount of columns and rows in the grid
            _gridXLength = 7;
            _gridYLength = 5;
            _gridX = new int[_gridXLength];
            _gridY = new int[_gridYLength];
        }

        /// <summary>
        /// METHOD 'Initialise' - Initialises the Engine Manager
        /// </summary>
        /// <param name="pSpriteFont">A Font for text</param>
        /// <param name="pHeight">The hight of the screen</param>
        /// <param name="pWidth">The width of the screen</param>
        public void Initialise(SpriteFont pSpriteFont, double pHeight, double pWidth)
        {
            // DECLARE two local variables to hold the width and height of the columns and rows
            int gridXAdd;
            int gridYAdd;
            
            //sets
            _height = pHeight;
            _width = pWidth;

            // SET the width and height of the rows and columns
            gridXAdd = (int)_width / _gridXLength;
            gridYAdd = (int)_height / _gridYLength;

            // Call Initialise method for Entity Manager
            _entityManager.Initialise(_factoryLocator);

            // CALL Initialise method for Collision Manager
            _collisionManager.Initialize(_entityManager.EntityList);

            // CALL Initialise method for Scene Manager passes pSpriteFont
            _sceneManager.Initialise(pSpriteFont);

            // ADD the first row and column to the grid
            _gridX[0] = 0;
            _gridY[0] = 0;

            // ADD the rest of the columns to the grid
            for (int i = 1; i < _gridXLength; i++)
            {
                _gridX[i] = _gridX[i - 1] + gridXAdd;
            }

            // ADD the rest of the rows to the grid
            for (int i = 1; i < _gridYLength; i++)
            {
                _gridY[i] = _gridY[i - 1] + gridYAdd;
            }
        }

        /// <summary>
        /// METHOD 'Update' - Updates the engine manager
        /// </summary>
        /// <param name="pHeight">The Height of the Screen</param>
        /// <param name="pWidth">The Width of the Screen</param>
        public void Update(double pHeight, double pWidth)
        {
            // CALL Update method inside InputManager class
            _inputManager.update();

            // CALL Update method inside CollisionManager class
            _collisionManager.update();

            // CALL Update method inside SceneManager class
            _sceneManager.Update(pHeight, pWidth);

            //CALL update method inside _commandSceduler
            _commandScheduler.Update();
        }

        /// <summary>
        /// METHOD 'LoadContent' - loads content
        /// </summary>
        /// <param name="pContent"></param>
        public void LoadContent(ContentManager pContent)
        {
            // DECLARE variable 'temptTexture' as type Texture2D - load 'square' texture onto ball
            Texture2D tempTexture = pContent.Load<Texture2D>("square");

            // DECLARE variable 'tempEntity' as type IEntity 
            IEntity tempEntity;

            //Creates a new Virus Entity
            tempEntity = _entityManager.CreateEntity<Virus>();

            //Calls intialise entity
            InitaliseEntity(tempEntity , tempTexture , new Vector2(-1 , -1));

            //Creates a new Cannon Entity
            tempEntity = _entityManager.CreateEntity<Cannon>();

            //Intialises cannon
            InitaliseEntity(tempEntity , tempTexture , new Vector2(-1, -1));

            //Subscribes cannon to _inputManager
            ((IClickPublisher)_inputManager).subscribe((IClickListener)tempEntity);

            //CREATEs a new Entity calld tempCannonBall
            IEntity tempCannonBall = _entityManager.CreateEntity<CannonBall>();
            //Initalises tempCannonBall
            InitaliseEntity(tempCannonBall , tempTexture , new Vector2());
            //Passes TempCannonBall to the cannon entity
            ((Cannon)tempEntity).SetCannonBall((CannonBall)tempCannonBall);
        }
        /// <summary>
        /// A Method that intialises entitys
        /// </summary>
        /// <param name="pEntity">The Entity being intialised</param>
        /// <param name="pTexture">The Texture of the entity</param>
        /// <param name="pPosition">the Position of the entity</param>
        private void InitaliseEntity(IEntity pEntity , Texture2D pTexture , Vector2 pPosition) 
        {
            //Sets the boundarys for tempEntity
            ((ICollidable)pEntity).setBoundaries(_width, _height);

            //Sets the texture of tempEntity to tempTexture
            ((EngineEntitys.IDrawable)pEntity).Content(pTexture);

            //Sets the starting location to _vector
            ((DrVsVirusEntity)pEntity).StartingLocation(pPosition);

            // PASS the grid to the entity
            ((DrVsVirusEntity)pEntity).SetGrid(_gridX, _gridY);

            //Adds tempEntity to the screen
            _sceneManager.AddEntity(pEntity);
        }

        /// <summary>
        /// A Method that draws entities onto the screen
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // CALL 'Draw' method inside SceneManager
            _sceneManager.draw(spriteBatch);
        }
    }
}
