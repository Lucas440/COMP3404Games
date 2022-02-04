using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP3451Project.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        // DECLARE Test list for COLLISION MANAGER'S Initialise method - will need removing
        private List<IEntity> _testList;

        /// <summary>
        /// CONSTRUCTOR for EngineManager
        /// </summary>
        public EngineManager(IFactoryLocator pfactoryLocator)
        {
            _factoryLocator = pfactoryLocator;

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
            // CALL Initialise method for Collision Manager
            _collisionManager.Initialize(_testList);

            // CALL Initialise method for Scene Manager
            _sceneManager.Initialise();

            // Call Initialise method for Entity Manager
            _entityManager.Initialise();
        }

    }
}
