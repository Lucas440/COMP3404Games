using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP2451Project;
using COMP3451.Entities;
using COMP3451.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        // DECLARE variable 'entity' as type IEntity
        private IEntity _entity;

        // DECLARE variable 'entities' as type IList<IEntity> - stores entities
        private IList<IEntity> _entities;

        // DECLARE variable '_entityList' as type IList<IEntity>
        public IList<IEntity> EntityList {  get => _entities; }

        // DECLARE variable '_paddleFactory' as type IFactory<Paddle>
        private IFactory<Paddle> _paddleFactory;

        // DECLARE variable '_ballFactory' as type IFactory<Ball>
        private IFactory<Ball> _ballFactory;

        /// <summary>
        /// CONSTRUCTOR 'EntityManager' - called upon Instantiation
        /// </summary>
        /// <param name="pPaddleFactory"></param>
        /// <param name="pBallFactory"></param>
        public EntityManager(IFactory<Paddle> pPaddleFactory, IFactory<Ball> pBallFactory) 
        {
            // INSTANTIATE a new entity list
            _entities = new List<IEntity>();

            // SET _paddleFactory to pPaddleFactory
            _paddleFactory = pPaddleFactory;

            // SET _ballFactory to pBallFactory parameter
            _ballFactory = pBallFactory;
        }

        /// <summary>
        /// METHOD 'Initialise' - Intialises EntityManager
        /// </summary>
        public void Initialise()
        {
            
        }

        /// <summary>
        /// METHOD 'CreateEntity'- creates entities
        /// </summary>
        /// <param name="which"></param>
        /// <param name="pLocation"></param>
        /// <param name="pTexture"></param>
        /// <returns></returns>
        public IEntity CreateEntity(int which , Vector2 pLocation , Texture2D pTexture)
        {
            // pOrderNumber dictates which entity will be instantiated

            /////////////////////////////
            // 1 = Paddle (Player 1)
            // 2 = Paddle (Player 2)
            // other = Ball
            /////////////////////////////

            // RETURN the chosen entity
            IEntity entity;
            if (which == 1)
            {
                //entity = new Paddle(pLocation, PlayerIndex.One);

                entity = _paddleFactory.Create<Paddle>();
                ((Paddle)entity).Initalise(pLocation, PlayerIndex.One);

                ((PongEntity)entity).Content(pTexture);
            }
            else if (which == 2) 
            {
                //entity = new Paddle(pLocation, PlayerIndex.Two);
                entity = _paddleFactory.Create<Paddle>();

                // CALL Initialise inside Paddle class - passing location and player index
                ((Paddle)entity).Initalise(pLocation, PlayerIndex.Two);

                // CALL Content inside PongEntity class - passing texture
                ((PongEntity)entity).Content(pTexture);
            }
            else 
            {                
                // CREATE a new ball using _ballFactory - SET to entity 
                entity = _ballFactory.Create<Ball>();

                // CALL Initialise inside Ball class - passing location
                ((Ball)entity).Initialise(pLocation);

                // CALL Content inside PongEntity class - passing texture
                ((PongEntity)entity).Content(pTexture);
            }

            // ADD entity to 'entities' list
            _entities.Add(entity);

            // RETURN entity
            return entity;
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
