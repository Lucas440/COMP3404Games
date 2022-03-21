using Engine.EngineEntitys;
using Engine.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGame.Entities;
using System;
using System.Collections.Generic;

/// <summary>
/// AUTHOR: Flynn Osborne
/// MODIFIED BY: William Eardley
/// DATE: 07/02/2022
/// </summary>
namespace COMP3451Project.Managers
{
    /// <summary>
    /// CLASS 'EntityManager' - Manages entities
    /// </summary>
    public class EntityManager
    {
        // DECLARE variable 'entities' as type IList<IEntity> - stores entities
        private IList<IEntity> _entities;

        // DECLARE variable '_entityList' as type IList<IEntity>
        public IList<IEntity> EntityList { get => _entities; }

        IFactoryLocator _factoryLocator;

        /// <summary>
        /// CONSTRUCTOR 'EntityManager' - called upon Instantiation
        /// </summary>
        /// <param name="pPaddleFactory"></param>
        /// <param name="pBallFactory"></param>
        public EntityManager()
        {
            // INSTANTIATE a new entity list
            _entities = new List<IEntity>();

        }


        /// <summary>
        /// METHOD 'Initialise' - Intialises EntityManager
        /// </summary>
        /// <param name="pLocator">A FactoryLocator</param>
        public void Initialise(IFactoryLocator pLocator)
        {
            //Sets _factoryLocator to pLocator
            _factoryLocator = pLocator;
        }


        /// <summary>
        /// METHOD 'CreateEntity'- creates entities
        /// </summary>
        /// <typeparam name="C">The Child Class of IEntity</typeparam>
        /// <returns>A New object of type IEntity</returns>
        public IEntity CreateEntity<C>() where C : IEntity, new()
        {
            //Creates and Returns a new IEntity using _factoryLoactor
            return (_factoryLocator.Get<IEntity>() as IFactory<IEntity>).Create<C>();
        }
        /// <summary>
        /// A method used to temerinate entites
        /// </summary>
        /// <param name="pEntity">the entity being terminated</param>
        public void Temerinate(IEntity pEntity)
        {
            //Removes pEntity from the list
            _entities.Remove(pEntity);
        }
    }
}
