using COMP3451Project.Managers;
using DrVsVirusGame.GameEntities;
using Engine.Command;
using Engine.EngineEntitys;
using Engine.Factories;
using Engine.InputEvents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

/// <summary>
/// CLASS: 'EngineManager' - manages game engine
/// AUTHOR: Will Eardley
/// MODIFIED BY: Flynn Osborne
/// DATE: 21/04/2022
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

        // DECLARE a IEntity called _points
        IEntity _points;

        // DECLARE a _int called _enemySpawnRate
        int _enemySpawnRate;

        // DECLARE an ICommand called _alterPointsCommand
        ICommand _alterPointsCommand;

        // DECLARE a random called Rnd
        Random rnd;

        // DECLARE an IEntity called _lives
        IEntity _lives;

        // DECLARE an ICommand called _reduceLivesCommand
        ICommand _reduceLivesCommand;

        // DECLARE a bool called _playing
        bool _playing;

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

            // SET _enemySpawnRate to 0
            _enemySpawnRate = 0;

            // INITIALISE random
            rnd = new Random();

            // SET _playing to false
            _playing = false;
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
            _sceneManager.Initialise(pSpriteFont, _entityManager.EntityList);

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

            // CALL update method inside _commandSceduler
            _commandScheduler.Update();

            // IF _playing is true:
            if (_playing)
            {

                // CALL Update method inside CollisionManager class
                _collisionManager.update();

                // CALL Update method inside SceneManager class
                _sceneManager.Update(pHeight, pWidth);

                // IF the lives are greater than or equal to 1:
                if (((Lives)_lives).LivesRemaining >= 1)
                {
                    // INCREMENT _enemySpawnRate
                    _enemySpawnRate++;
                }

                // IF the _enemySpawnRate is greater than or equal to 120:
                if (_enemySpawnRate >= 120)
                {
                    // CREATE an enemy
                    CreateEnemy();

                    // RESET _enemySpawnRate
                    _enemySpawnRate = 0;
                }

                // IF the number of lives remaining is 0:
                if (((Lives)_lives).LivesRemaining == 0)
                {
                    // CLEAR all entities
                    _entityManager.EntityList.Clear();

                    // LOAD the endScreen
                    LoadEndScreen();

                    // REDUCE the lives
                    ((Lives)_lives).ReduceLives();
                }
            }
        }
        /// <summary>
        /// A Method that loads the main menu
        /// </summary>
        /// <param name="pContent">A Content Manager</param>
        public void LoadMainMenu(ContentManager pContent)
        {
            // SET _content to pContent
            _content = pContent;

            // DECLARE an IEntity called tempEntity - intialise as a gamebutton
            IEntity tempEntity = _entityManager.CreateEntity<GameButton>();
            // INITIALISE the entity
            InitaliseEntity(tempEntity, _content.Load<Texture2D>("Play Button"), new Vector2(700, 350));
            // SET the entity commands
            SetCommands(tempEntity);
            // SUBSCRIBE the entity
            ((IClickPublisher)_inputManager).subscribe((IClickListener)tempEntity);
            // DECLARE a ICommand called loadMainGame
            ICommand loadMainGame = (_factoryLocator.Get<ICommand>() as IFactory<ICommand>).Create<CommandZeroParam>();
            // SET the action to the method LoadMainGame
            ((ICommandZeroParam)loadMainGame).SetAction = LoadMainGame;
            // SET the button Clicked command to loadMainGame
            ((GameButton)tempEntity).ButtonClicked = loadMainGame;

            // DECLARE an IEntity called tempEntity - intialise as a gamebutton
            tempEntity = _entityManager.CreateEntity<GameButton>();
            // INITIALISE the entity
            InitaliseEntity(tempEntity, _content.Load<Texture2D>("HowToPlayButton"), new Vector2(1000, 750));
            // SET the entity commands
            SetCommands(tempEntity);
            // SUBSCRIBE the entity
            ((IClickPublisher)_inputManager).subscribe((IClickListener)tempEntity);
            // DECLARE a ICommand called loadMainGame
            ICommand loadHowToPlay = (_factoryLocator.Get<ICommand>() as IFactory<ICommand>).Create<CommandZeroParam>();
            // SET the action to the method LoadMainGame
            ((ICommandZeroParam)loadHowToPlay).SetAction = LoadHowToPlay;
            // SET the button Clicked command to loadMainGame
            ((GameButton)tempEntity).ButtonClicked = loadHowToPlay;


        }
        /// <summary>
        /// A Method to load the main menu
        /// </summary>
        private void LoadMainMenu()
        {
            // LOOP over every Listener and removes them
            foreach (IEntity e in _entityManager.EntityList)
            {
                if (e is IClickListener)
                {
                    ((IClickPublisher)_inputManager).unSubscribe((IClickListener)e);
                }
            }

            // CLEAR the entities
            _entityManager.EntityList.Clear();

            // LOAD the MainMenu
            LoadMainMenu(_content);
        }

        private void LoadHowToPlay()
        {
            // LOOP over every Listener and removes them
            foreach (IEntity e in _entityManager.EntityList)
            {
                if (e is IClickListener) 
                {
                    ((IClickPublisher)_inputManager).unSubscribe((IClickListener)e);
                }
            }
            // CLEAR entities
            _entityManager.EntityList.Clear();

            // SET the Texture to DefenderButton
            Texture2D tempTexture = _content.Load<Texture2D>("DefenderButton");
            // CREATE and INITIALISE the entity
            IEntity tempEntity = _entityManager.CreateEntity<DefenderButton>();
            InitaliseEntity(tempEntity, tempTexture, new Vector2(100, 500));
            // SET the StateText
            tempEntity.StateText = "                            This Defender Button will allow you to place Defenders for 200 Points each";

            // CREATE a new Game Button
            tempEntity = _entityManager.CreateEntity<GameButton>();
            // INITIALISE the entity
            InitaliseEntity(tempEntity, _content.Load<Texture2D>("HealthIcon"), new Vector2(100, 650));
            // SET commands for the entity
            SetCommands(tempEntity);
            // SET the StateText
            tempEntity.StateText = "                            This Health Button will give you extra lives for 500 Points each, though you can only have a maximum of 3.";

            // CREATE a new Game Button  
            tempEntity = _entityManager.CreateEntity<GameButton>();
            // INITIALISE the entity
            InitaliseEntity(tempEntity, _content.Load<Texture2D>("NukeButton"), new Vector2(100, 800));
            // SET commands for the entity
            SetCommands(tempEntity);
            // SET the StateText
            tempEntity.StateText = "                            This Nuke Button will remove all enemies for 1000 Points";


            // CREATE a new Virus Entity
            tempEntity = _entityManager.CreateEntity<Virus>();
            // INITIALISE a variable to the Square texture
            tempTexture = _content.Load<Texture2D>("Virus");

            // CALL IntialiseEntity giving a random hight and distance from the goal
             InitaliseEntity(tempEntity, tempTexture, new Vector2(800 , 300));

            // CREATE a new Bacteria Entity
            tempEntity = _entityManager.CreateEntity<Bacteria>();
            // INITIALISE a variable to the Square texture
            tempTexture = _content.Load<Texture2D>("Bacteria");

            // CALL IntialiseEntity giving a random hight and distance from the goal
            InitaliseEntity(tempEntity, tempTexture, new Vector2(800, 400));

            // CREATE a new Fungus Entity
            tempEntity = _entityManager.CreateEntity<Fungi>();
            // INITIALISE a variable to the Square texture
            tempTexture = _content.Load<Texture2D>("Fungi");

            // CALL IntialiseEntity giving a random hight and distance from the goal
            InitaliseEntity(tempEntity, tempTexture, new Vector2(800, 500));

            // SET the StateText to
            tempEntity.StateText = "                 These are the enemies you will be defending against:";

            // DECLARE an IEntity called tempEntity - intialise as a gamebutton
            tempEntity = _entityManager.CreateEntity<GameButton>();
            // INITIALISE the entity
            InitaliseEntity(tempEntity, _content.Load<Texture2D>("ReturnButton"), new Vector2(1000, 750));
            // SET the entity commands
            SetCommands(tempEntity);
            // SUBSCRIBE the entity
            ((IClickPublisher)_inputManager).subscribe((IClickListener)tempEntity);
            // DECLARE a ICommand called loadMainGame
            ICommand loadMainMenu = (_factoryLocator.Get<ICommand>() as IFactory<ICommand>).Create<CommandZeroParam>();
            // SET the action to the method LoadMainGame
            ((ICommandZeroParam)loadMainMenu).SetAction = LoadMainMenu;
            // SET the button Clicked command to loadMainGame
            ((GameButton)tempEntity).ButtonClicked = loadMainMenu;

        }

        /// <summary>
        /// A Method that loaded the End Screen
        /// </summary>
        private void LoadEndScreen()
        {
            // CREATE an entity of type endScreenComponent
            IEntity tempEntity = _entityManager.CreateEntity<EndScreenComponent>();
            // SET the text of the entity
            tempEntity.StateText = "Game Over! Your Score was " + ((Points)_points).TotalPoints;
            // SET the location
            ((DrVsVirusEntity)tempEntity).StartingLocation(new Vector2(700, 450));

            // DECLARE an IEntity called tempEntity - intialise as a gamebutton
            tempEntity = _entityManager.CreateEntity<GameButton>();
            // INITIALISE the entity
            InitaliseEntity(tempEntity, _content.Load<Texture2D>("ReturnButton"), new Vector2(1000, 750));
            // SET the entity commands
            SetCommands(tempEntity);
            // SUBSCRIBE the entity
            ((IClickPublisher)_inputManager).subscribe((IClickListener)tempEntity);
            // DECLARE a ICommand called loadMainGame
            ICommand loadMainMenu = (_factoryLocator.Get<ICommand>() as IFactory<ICommand>).Create<CommandZeroParam>();
            // SET the action to the method LoadMainGame
            ((ICommandZeroParam)loadMainMenu).SetAction = LoadMainMenu;
            // SET the button Clicked command to loadMainGame
            ((GameButton)tempEntity).ButtonClicked = loadMainMenu;
        }

        /// <summary>
        /// METHOD 'LoadContent' - loads content
        /// </summary>
        public void LoadMainGame()
        {

            // DECLARE variable 'temptTexture' as type Texture2D
            Texture2D tempTexture;

            // LOOP over each IClickListener and remove them
            foreach (IClickListener listener in _entityManager.EntityList)
            {
                ((IClickPublisher)_inputManager).unSubscribe(listener);
            }

            // CLEAR the entities
            _entityManager.EntityList.Clear();

            // SET _playing to true
            _playing = true;

            // INITIALISE _lives
            _lives = _entityManager.CreateEntity<Lives>();
            // INITIALSES _reduceLivesCommand
            _reduceLivesCommand = (_factoryLocator.Get<ICommand>() as IFactory<ICommand>).Create<CommandZeroParam>();
            // SET the action to ReduceLives
            ((ICommandZeroParam)_reduceLivesCommand).SetAction = ((Lives)_lives).ReduceLives;

            // SET the starting location 1400, 50
            ((DrVsVirusEntity)_lives).StartingLocation(new Vector2(1000, 50));

            // INITIALISE _points
            _points = _entityManager.CreateEntity<Points>();
            // SET the starting location 1400, 50
            ((DrVsVirusEntity)_points).StartingLocation(new Vector2(1400, 50));

            // INITIALISE _alterPointsCommand
            _alterPointsCommand = (_factoryLocator.Get<ICommand>() as IFactory<ICommand>).Create<CommandOneParam<int>>();
            // SET the action to AlterPoints
            ((ICommandOneParam<int>)_alterPointsCommand).SetAction = ((Points)_points).AlterPoints;
            // SET the data to 100
            ((ICommandOneParam<int>)_alterPointsCommand).SetData = 100;

            // LOAD 'square' texture onto ball
            tempTexture = _content.Load<Texture2D>("square");

            // DECLARE variable 'tempEntity' as type IEntity 
            IEntity tempEntity;


            // CREATE a new Cannon Entity
            tempEntity = _entityManager.CreateEntity<Cannon>();

            // INITIALISE the cannon
            InitaliseEntity(tempEntity, tempTexture, new Vector2(-1, -1));

            // SUBSCRIBE the cannon to _inputManager
            ((IClickPublisher)_inputManager).subscribe((IClickListener)tempEntity);

            // CREATE a new Entity called tempCannonBall
            IEntity tempCannonBall = _entityManager.CreateEntity<CannonBall>();

            // INITIALISE tempCannonBall
            InitaliseEntity(tempCannonBall, tempTexture, new Vector2());

            // PASS tempCannonBall to the cannon entity
            ((Cannon)tempEntity).SetCannonBall((CannonBall)tempCannonBall);
            // SET the Texture to DefenderButton
            tempTexture = _content.Load<Texture2D>("DefenderButton");

            // CREATE & INITIALISE a Defender Button
            tempEntity = _entityManager.CreateEntity<DefenderButton>();
            InitaliseEntity(tempEntity, tempTexture, new Vector2(100, 500));
            SetCommands(tempEntity);
            // SUBSCRIBE the cannon to _inputManager
            ((IClickPublisher)_inputManager).subscribe((IClickListener)tempEntity);
            // CREATE a new ICommand called createDefender
            ICommand createDefender = (_factoryLocator.Get<ICommand>() as IFactory<ICommand>).Create<CommandOneParam<Vector2>>();
            // SET the action to the method CreateDefender
            ((ICommandOneParam<Vector2>)createDefender).SetAction = CreateDefender;
            // SET the command in the entity to createDefender
            ((DefenderButton)tempEntity).CreateDefender = createDefender;

            // CREATE a new Game Button
            tempEntity = _entityManager.CreateEntity<GameButton>();
            // INITIALISE the entity
            InitaliseEntity(tempEntity, _content.Load<Texture2D>("HealthIcon"), new Vector2(100, 650));
            // SET commands for the entity
            SetCommands(tempEntity);
            // SUBSCRIBE the entity to Clicks
            ((IClickPublisher)_inputManager).subscribe((IClickListener)tempEntity);
            // CREATE a ICommand called increaseLivesCommand
            ICommand increaseLivesCommand = (_factoryLocator.Get<ICommand>() as IFactory<ICommand>).Create<CommandZeroParam>();
            // SET the action to the method IncreaseLives
            ((ICommandZeroParam)increaseLivesCommand).SetAction = IncreaseLives;
            // SET the ButtonClick command to increaseLivesCommand
            ((GameButton)tempEntity).ButtonClicked = increaseLivesCommand;

            // CREATE a new Game Button
            tempEntity = _entityManager.CreateEntity<GameButton>();
            // INITIALISE the entity
            InitaliseEntity(tempEntity, _content.Load<Texture2D>("NukeButton"), new Vector2(100, 800));
            // SET commands for the entity
            SetCommands(tempEntity);
            // SUBSCRIBE the entity to Clicks
            ((IClickPublisher)_inputManager).subscribe((IClickListener)tempEntity);
            // CREATE a ICommand called nukeCommand
            ICommand nukeCommand = (_factoryLocator.Get<ICommand>() as IFactory<ICommand>).Create<CommandZeroParam>();
            // SET the action to the method Nuke
            ((ICommandZeroParam)nukeCommand).SetAction = Nuke;
            // SET the ButtonClick command to Nuke
            ((GameButton)tempEntity).ButtonClicked = nukeCommand;


        }
        /// <summary>
        /// A Method which removes all enemies
        /// </summary>
        private void Nuke()
        {
            IList<Enemy> removeList = new List<Enemy>();

            // IF the player has 1000 points or more:
            if (((Points)_points).CurrentPoints >= 1000)
            {
                // LOOP over each enemy in the entity list
                foreach (IEntity e in _entityManager.EntityList)
                {
                    // IF the entity is an enemy:
                    if (e is Enemy)
                    {
                        // ADD the enemy to the remove list
                        removeList.Add((Enemy)e);
                    }
                }
                // LOOP over the remove list
                for (int i = 0; i < removeList.Count; i++)
                {
                    // REMOVE and TERMINATE the enemy
                    _sceneManager.Remove(removeList[i]);
                    _entityManager.Temerinate(removeList[i]);
                }
                // SET _enemySpawnRate to 0
                _enemySpawnRate = 0;
                // DECREASE points by 1000
                ((Points)_points).AlterPoints(-1000);

            }
        }

        /// <summary>
        /// A Method used to Increase the amount of lives the player hass
        /// </summary>
        private void IncreaseLives()
        {
            // IF the player has 500 points or more and the player has less than 3 lives:
            if (((Points)_points).CurrentPoints >= 500 && ((Lives)_lives).LivesRemaining < 3)
            {
                // INCREASE lives
                ((Lives)_lives).IncreaseLives();
                // DECREASE points by 500
                ((Points)_points).AlterPoints(-500);
            }
        }

        /// <summary>
        /// A Method used to create enemys
        /// </summary>
        private void CreateEnemy()
        {
            // GENERATE a random number from 1 to 3
            int enemyType = rnd.Next(1, 4);

            // DECLARE variable 'tempEntity' as type IEntity 
            IEntity tempEntity = null;
            // INITIALISE a variable to the Square texture
            Texture2D tempTexture = null;

            //enemyType = 1;

            if (enemyType == 1)
            {
                // CREATE a new Virus Entity
                tempEntity = _entityManager.CreateEntity<Virus>();
                //INITIALISE a variable to the Square texture
                tempTexture = _content.Load<Texture2D>("Virus");
            }
            else if (enemyType == 2)
            {
                // CREATE a new Bacteria Entity
                tempEntity = _entityManager.CreateEntity<Bacteria>();
                // INITIALISE a variable to the Square texture
                tempTexture = _content.Load<Texture2D>("Bacteria");
            }
            else
            {
                // CREATE a new Fungus Entity
                tempEntity = _entityManager.CreateEntity<Fungi>();
                // INITIALISE a variable to the Square texture
                tempTexture = _content.Load<Texture2D>("Fungi");
            }
            // CALL InitaliseEntity giving a random hight and distance from the goal
            InitaliseEntity(tempEntity, tempTexture, new Vector2((float)(_width + rnd.Next(50, 150)), rnd.Next(0, Convert.ToInt32(_height))));

            // CALL SetCommands
            SetCommands(tempEntity);
            // SET the Command in the entity to _alterPointsCommand and _reduceLivesCommand
            ((Enemy)tempEntity).AlterPoints = _alterPointsCommand;
            ((Enemy)tempEntity).ReduceLives = _reduceLivesCommand;
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
                // DECLARE a IEntity called tempDefender
                IEntity tempDefender;
                // DECLARE a Texture2D called tempTexture
                Texture2D tempTexture;

                // CREATE a new Defender
                tempDefender = _entityManager.CreateEntity<Defender>();
                // LOAD the defender Projectile texture
                tempTexture = _content.Load<Texture2D>("DefenderProjectile");
                // CREATE a defender Projectile
                IEntity tempProjectile = _entityManager.CreateEntity<DefenderProjectile>();
                // SET the texture to the projectile texture
                ((EngineEntitys.IDrawable)tempProjectile).Content(tempTexture);
                // SET tempTexture to "square"
                tempTexture = _content.Load<Texture2D>("square");
                // SET the defenders projectile to tempProjectile
                ((Defender)tempDefender).SetProjectile = (DefenderProjectile)tempProjectile;
                // CREATE a new Entity sight
                IEntity tempSight = _entityManager.CreateEntity<EntitySight>();
                // SET the Defenders sight to tempSight
                ((Defender)tempDefender).SetSight = (EntitySight)tempSight;

                // INITIALISE the defender
                InitaliseEntity(tempDefender, tempTexture, pLocn);
                // DECREASE the points by 200
                ((Points)_points).AlterPoints(-200);

                // SET commands for the objects
                SetCommands(tempDefender);
                SetCommands(tempSight);
                SetCommands(tempProjectile);

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
        private void InitaliseEntity(IEntity pEntity, Texture2D pTexture, Vector2 pPosition)
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
