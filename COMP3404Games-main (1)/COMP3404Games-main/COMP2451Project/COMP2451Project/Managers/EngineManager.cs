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
/// DATE: 04/04/2022
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

        // DECLARE a private variable called _commandScheduler as ICommandScheduler
        private ICommandScheduler _commandScheduler;

        // DECLARE two doubles _height and _width
        double _height, _width;

        // DECLARE two arrays to contain the grid
        int[] _gridX;
        int[] _gridY;

        // DECLARE two variables to hold the number of rows and columns in the grid
        int _gridXLength, _gridYLength;

        // DECLARE two integer variables to hold the end points of the grid
        int _gridXEnd, _gridYEnd;

        // DECLARE two integer variables to hold the start points of the grid
        int _gridXStart, _gridYStart;

        // DECLARE a ContentManager called _content
        ContentManager _content;

        IEntity _points;

        /// <summary>
        /// CONSTRUCTOR for EngineManager
        /// </summary>
        public EngineManager(IFactoryLocator pfactoryLocator)
        {
            // SET _factoryLocator to pfactoryLocator parameter
            _factoryLocator = pfactoryLocator;

            // INITIALISE _inputManager
            _inputManager = (_factoryLocator.Get<IEventPublisher>() as IFactory<IEventPublisher>).Create<InputManager>();

            // INSTANTIATE '_sceneManager' as new SceneManager
            _sceneManager = (_factoryLocator.Get<SceneManager>() as IFactory<SceneManager>).Create<SceneManager>();

            // INSTANTIATE '_collisionManager' as new CollisionManager
            _collisionManager = (_factoryLocator.Get<ColisionManager>() as IFactory<ColisionManager>).Create<ColisionManager>();

            // INSTANTIATE '_entityManager' as new EntityManager
            _entityManager = (_factoryLocator.Get<EntityManager>() as IFactory<EntityManager>).Create<EntityManager>();

            // INSTANTIATE _commandScheduler as new CommandSchedular
            _commandScheduler = (_factoryLocator.Get<ICommandScheduler>() as IFactory<ICommandScheduler>).Create<CommandScheduler>();

            // SET the amount of columns and rows in the grid
            _gridXLength = 6;
            _gridYLength = 4;
            _gridX = new int[_gridXLength];
            _gridY = new int[_gridYLength];

            // SET the endpoints for the grid's rows and columns
            _gridXEnd = 1445;
            _gridYEnd = 810;

            // SET the start points for the grid
            _gridXStart = 495;
            _gridYStart = 115;
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
            
            // SET the width and height of the screen
            _height = pHeight;
            _width = pWidth;

            // SET the width and height of the grid's rows and columns
            //gridXAdd = (int)_width / _gridXLength;
            //gridYAdd = (int)_height / _gridYLength;

            gridXAdd = (_gridXEnd - _gridXStart) / _gridXLength;
            gridYAdd = (_gridYEnd - _gridYStart) / _gridYLength;

            // CALL Initialise method for Entity Manager
            _entityManager.Initialise(_factoryLocator);

            // CALL Initialise method for Collision Manager
            _collisionManager.Initialize(_entityManager.EntityList);

            // CALL Initialise method for Scene Manager (passing pSpriteFont)
            _sceneManager.Initialise(pSpriteFont , _entityManager.EntityList);

            // ADD the first row and column to the grid
            //_gridX[0] = 0;
            //_gridY[0] = 0;

            _gridX[0] = _gridXStart;
            _gridY[0] = _gridYStart;

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
            ICommand alterPointsCommand = (_factoryLocator.Get<ICommand>() as IFactory<ICommand>).Create<CommandOneParam<int>>();
            ((ICommandOneParam<int>)alterPointsCommand).SetData = 100;
            

            //Sets _content to pContent
            _content = pContent;

            // DECLARE variable 'temptTexture' as type Texture2D - load 'square' texture onto ball
            Texture2D tempTexture = pContent.Load<Texture2D>("square");

            // DECLARE variable 'tempEntity' as type IEntity 
            IEntity tempEntity;

            Random rnd = new Random();

            //Creates a set amount of Virus
            for (int x = 0; x < 10; x++) 
            {
                //Creates a new Virus Entity
                tempEntity = _entityManager.CreateEntity<Virus>();

                //Calls intialise entity giving a random hight and distance from the goal
                InitaliseEntity(tempEntity, tempTexture, new Vector2((float)(_width + rnd.Next(50, 150)), rnd.Next(0, Convert.ToInt32(_height))));

                //Calls SetCommands
                SetCommands(tempEntity);
                ((Enemy)tempEntity).AlterPoints = alterPointsCommand;
            }


            //Creates a new Cannon Entity
            tempEntity = _entityManager.CreateEntity<Cannon>();

            // INITIALISE the cannon
            InitaliseEntity(tempEntity , tempTexture , new Vector2(-1, -1));

            // SUBSCRIBE the cannon to _inputManager
            ((IClickPublisher)_inputManager).subscribe((IClickListener)tempEntity);

            // CREATE a new Entity called tempCannonBall
            IEntity tempCannonBall = _entityManager.CreateEntity<CannonBall>();

            // INITIALISE tempCannonBall
            InitaliseEntity(tempCannonBall , tempTexture , new Vector2());

            // PASS tempCannonBall to the cannon entity
            ((Cannon)tempEntity).SetCannonBall((CannonBall)tempCannonBall);

            tempEntity = _entityManager.CreateEntity<DefenderButton>();
            InitaliseEntity(tempEntity , tempTexture , new Vector2(100 , 500));
            SetCommands(tempEntity);
            // SUBSCRIBE the cannon to _inputManager
            ((IClickPublisher)_inputManager).subscribe((IClickListener)tempEntity);

            ICommand createDefender = (_factoryLocator.Get<ICommand>() as IFactory<ICommand>).Create<CommandOneParam<Vector2>>();
            ((ICommandOneParam<Vector2>)createDefender).SetAction = CreateDefender;

            ((DefenderButton)tempEntity).CreateDefender = createDefender;


            _points = _entityManager.CreateEntity<Points>();
            ((DrVsVirusEntity)_points).StartingLocation(new Vector2(1400 , 50));
            ((ICommandOneParam<int>)alterPointsCommand).SetAction = ((Points)_points).AlterPoints;
            _sceneManager.Points = _points;

        }

        /// <summary>
        /// A Method used to Create a Defender
        /// </summary>
        /// <param name="pLocn"></param>
        /// <param name="pContent"></param>
        private void CreateDefender(Vector2 pLocn) 
        {
            if (((Points)_points).CurrentPoints >= 200)
            {
                //DECLARE a IEntity called tempDefender
                IEntity tempDefender;
                //DECLARE a Texture2D called tempTexture
                Texture2D tempTexture;

                //Create a new Defender
                tempDefender = _entityManager.CreateEntity<Defender>();
                //Load the defender Projectile texture
                tempTexture = _content.Load<Texture2D>("DefenderProjectile");
                //Create a defender Projectile
                IEntity tempProjectile = _entityManager.CreateEntity<DefenderProjectile>();
                //Set the texture to the projectile texture
                ((EngineEntitys.IDrawable)tempProjectile).Content(tempTexture);
                //Sets tempTexture to "square"
                tempTexture = _content.Load<Texture2D>("square");
                //Sets the defenders projectile to tempProjectile
                ((Defender)tempDefender).SetProjectile = (DefenderProjectile)tempProjectile;
                //Creates a new Entity sight
                IEntity tempSight = _entityManager.CreateEntity<EntitySight>();
                //Sets the Defenders sight to tempSight
                ((Defender)tempDefender).SetSight = (EntitySight)tempSight;

                //Initalises the defender
                InitaliseEntity(tempDefender, tempTexture, pLocn);

                ((Points)_points).AlterPoints(-200);
            }
        }

        /// <summary>
        /// A Method which sets the commands for an Entity
        /// </summary>
        /// <param name="pEntity">The entity the commands will be set for</param>
        private void SetCommands(IEntity pEntity)
        {

            // CREATE a new ICommand called removeCommand
            ICommand removeCommand = (_factoryLocator.Get<ICommandOneParam<IEntity>>() as IFactory<ICommandOneParam<IEntity>>).Create<CommandOneParam<IEntity>>();
            // CREATE a new ICommand called terminateCommand
            ICommand terminateCommand = (_factoryLocator.Get<ICommandOneParam<IEntity>>() as IFactory<ICommandOneParam<IEntity>>).Create<CommandOneParam<IEntity>>();
            // CREATE a new ICommand called schedualCommand
            ICommand schedualCommand = (_factoryLocator.Get<ICommandOneParam<Action>>() as IFactory<ICommandOneParam<Action>>).Create<CommandOneParam<Action>>();

            // SET the action of the removeCommand to _secneManager's Remove method
            ((ICommandOneParam<IEntity>)removeCommand).SetAction = _sceneManager.Remove;
            // SET the data of the command to the Entity
            ((ICommandOneParam<IEntity>)removeCommand).SetData = pEntity;
            // SET the RemoveMe command to removeCommand
            ((IEntityInternal)pEntity).RemoveMe = removeCommand;

            // SET the action of the terminateCommand to _entityManager's Temerinate method
            ((ICommandOneParam<IEntity>)terminateCommand).SetAction = _entityManager.Temerinate;
            // SET the data of the command to the Entity
            ((ICommandOneParam<IEntity>)terminateCommand).SetData = pEntity;
            // SET the TerminateMe command to terminateCommand
            ((IEntityInternal)pEntity).TerminateMe = terminateCommand;

            // SET ScheduleCommand to _commandScheduler ExecuteCommand Method
            ((ICommandSender)pEntity).ScheduleCommand = _commandScheduler.ExecuteCommand;
        }

        /// <summary>
        /// A Method that intialises entities
        /// </summary>
        /// <param name="pEntity">The Entity being initialised</param>
        /// <param name="pTexture">The Texture of the entity</param>
        /// <param name="pPosition">the Position of the entity</param>
        private void InitaliseEntity(IEntity pEntity , Texture2D pTexture , Vector2 pPosition) 
        {
            // SET the boundaries for tempEntity
            ((ICollidable)pEntity).setBoundaries(_width, _height);

            // SET the texture of tempEntity to tempTexture
            ((EngineEntitys.IDrawable)pEntity).Content(pTexture);

            // SET the starting location to _vector
            ((DrVsVirusEntity)pEntity).StartingLocation(pPosition);

            // PASS the grid to the entity
            ((DrVsVirusEntity)pEntity).SetGrid(_gridX, _gridY);
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
