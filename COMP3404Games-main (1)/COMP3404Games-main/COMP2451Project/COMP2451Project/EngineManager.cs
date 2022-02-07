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
    /// CLASS 'EngineManager' - manages game engine
    /// AUTHOR: Will Eardley
    /// DATE: 07/02/22
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

        // DECLARE a private variable calld_inputManager as IEventPublisher
        private IEventPublisher _inputManager;

        /// <summary>
        /// CONSTRUCTOR for EngineManager
        /// </summary>
        public EngineManager(IFactoryLocator pfactoryLocator)
        {
            // SET _factoryLocator to pfactoryLocator parameter
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
        /// METHOD 'Update' - Updates the engine manager
        /// </summary>
        /// <param name="pHeight">The Height of the Screen</param>
        /// <param name="pWidth">The Width of the Screen</param>
        public void Update(double pHeight , double pWidth) 
        {
            // CALL Update method inside InputManager class
            _inputManager.update();

            // CALL Update method inside CollisionManager class
            _collisionManager.update();

            // CALL Update method inside SceneManager class
            _sceneManager.update(pHeight , pWidth);
        }

        /// <summary>
        /// METHOD 'LoadContent' - loads content
        /// </summary>
        /// <param name="pContent"></param>
        public void LoadContent(ContentManager pContent) 
        {
            ///
            // BALL INITIALISE
            ///

            // DECLARE variable 'temptTexture' as type Texture2D - load 'square' texture onto ball
            Texture2D tempTexture = pContent.Load<Texture2D>("square");
            
            // DECLARE variable 'tempEntity' as type IEntity 
            IEntity tempEntity;
            
            // DECLARE AND INSTANTIATE variable 'v' as new Vector2
            Vector2 _vector = new Vector2();

            // SET 'vector' X coordinate to 500
            _vector.X = 500;
            
            // SET 'vector' Y coordinate to 500
            _vector.Y = 500;
            
            // SET 'tempEntity' to value returned from CreateEntity method inside EntityManager
            tempEntity = _entityManager.CreateEntity(3, _vector, tempTexture);

            // CALL 'AddEntity' method inside SceneManager - passing tempEntity
            _sceneManager.addEntity(tempEntity);

            ///
            // PADDLE 1 INITIALISE
            /// 

            // SET 'tempTexture' to 'paddle' texture from 'Load' method - assign paddle texture to paddles
            tempTexture = pContent.Load<Texture2D>("paddle");

            // SET '_vector' X coordinate to 0
            _vector.X = 0;

            // SET '_vector' Y coordinate to 0
            _vector.Y = 0;

            // SET 'tempEntity' to value returned from CreateEntity method inside EntityManager
            tempEntity = _entityManager.CreateEntity(1, _vector, tempTexture);

            // CALL Subscribe method inside InputManager - subscribes to an input publisher
            ((IInputPublisher)_inputManager).subscribe(((IKeyListener)tempEntity));

            // CALL 'AddEntity' method inside SceneManager to ADD entity to scene
            _sceneManager.addEntity(tempEntity);

            ///
            // PADDLE 2 INITIALISE
            ///

            // SET '_vector' X coordinate to 850
            _vector.X = 850;

            // SET '_vector' Y coordinate to 0
            _vector.Y = 0;

            // SET 'tempEntity' to value returned from CreateEntity method inside EntityManager
            tempEntity = _entityManager.CreateEntity(2, _vector, tempTexture);

            // CALL 'Subscribe' method inside InputManager - subscribes to an input publisher
            ((IInputPublisher)_inputManager).subscribe(((IKeyListener)tempEntity));

            // CALL 'AddEntity' method inside SceneManager to ADD entity to scene
            _sceneManager.addEntity(tempEntity);
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
