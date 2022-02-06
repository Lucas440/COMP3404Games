using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP3451Project.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using COMP3451Project.Managers.Input;

namespace COMP2451Project
{
    /// <summary>
    /// AUTHOR: Will Eardley
    /// DATE: 31/01/22
    /// </summary>
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
        //DECLARE a private variable calld_inputManager as IEventPublisher
        private IEventPublisher _inputManager;

        /// <summary>
        /// CONSTRUCTOR for EngineManager
        /// </summary>
        public EngineManager(IFactoryLocator pfactoryLocator)
        {
            _factoryLocator = pfactoryLocator;
            //INTALISES _inputManager
            _inputManager = new InputManager();

            // INSTANTIATE '_sceneManager' as new SceneManager
            _sceneManager = new SceneManager();

            // INSTANTIATE '_collisionManager' as new CollisionManager
            _collisionManager = new ColisionManager();

            // INSTANTIATE '_entityManager' as new EntityManager
            _entityManager = new EntityManager(_factoryLocator.Get<Paddle>() as IFactory<Paddle>, _factoryLocator.Get<Ball>() as IFactory<Ball>);
        }

        /// <summary>
        /// METHOD 'Initialise' - Initialises the Engine Manager
        /// </summary>
        public void Initialise()
        {
            // Call Initialise method for Entity Manager
            _entityManager.Initialise();

            // CALL Initialise method for Collision Manager
            _collisionManager.Initialize(_entityManager.EntityList);

            // CALL Initialise method for Scene Manager
            _sceneManager.Initialise();
        }
        /// <summary>
        /// Updates the engine manager
        /// </summary>
        /// <param name="pHeight">The Height of the Screen</param>
        /// <param name="pWidth">The Width of the Screen</param>
        public void update(double pHeight , double pWidth) 
        {
            //Updates _inputManager
            _inputManager.update();
            //Updates Colision Manager
            _collisionManager.update();
            //Updates Scene Manager
            _sceneManager.update(pHeight , pWidth);
        }

        public void LoadContent(ContentManager pContent) 
        {
            //Loads the ball texture into tempTexture
            Texture2D tempTexture = pContent.Load<Texture2D>("square");
            IEntity tempEntity;
            Vector2 v = new Vector2();
            v.X = 500;
            v.Y = 500;
            //Creates a new Entity and stores it in temp entity
            tempEntity = _entityManager.CreateEntity(3, v, tempTexture);

            // calls the add entity method in scene passing the return value of create ball
            _sceneManager.addEntity(tempEntity);

            // loads the paddle texture into temp
            tempTexture = pContent.Load<Texture2D>("paddle");

            v.X = 0;
            v.Y = 0;
            //Creates a new Entity and stores it in temp entity
            tempEntity = _entityManager.CreateEntity(1, v, tempTexture);
            //Subscribes tempEntity to the event publisher
            ((IInputPublisher)_inputManager).subscribe(((IKeyListener)tempEntity));
            //Adds the entity to the scene
            _sceneManager.addEntity(tempEntity);

            v.X = 850;
            v.Y = 0;
            //Creates a new Entity and stores it in temp entity
            tempEntity = _entityManager.CreateEntity(2, v, tempTexture);
            //Subscribes tempEntity to the event publisher
            ((IInputPublisher)_inputManager).subscribe(((IKeyListener)tempEntity));
            //Adds the entity to the scene
            _sceneManager.addEntity(tempEntity);
        }
        /// <summary>
        /// A Method that draws entities onto the screen
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch</param>
        public void Draw(SpriteBatch spriteBatch) 
        {
            _sceneManager.draw(spriteBatch);
        }

    }
}
