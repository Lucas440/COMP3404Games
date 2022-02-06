using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP2451Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
/// <summary>
/// AUTHOR: Flynn Osborne
/// DATE: 19/01/2022
/// </summary>
namespace COMP3451Project.Managers
{
   public class EntityManager
    {
        // Variable to hold game entity
        public IEntity entity;

        // List to hold the entities
        public IList<IEntity> entities;

        public IList<IEntity> EntityList {  get => entities; }

        // Variables to hold factories for the ball and paddles
        public IFactory<Paddle> _paddleFactory;
        public IFactory<Ball> _ballFactory;

        public EntityManager(IFactory<Paddle> pPaddleFactory, IFactory<Ball> pBallFactory) 
        {
            // Create a new entity list
            entities = new List<IEntity>();

            // Initialise the ball and paddle factories
            _paddleFactory = pPaddleFactory;
            _ballFactory = pBallFactory;
        }

        /// <summary>
        /// METHOD 'Initialise' - Intialises EntityManager
        /// </summary>
        public void Initialise()
        {
            
        }

        public IEntity CreateEntity(int which , Vector2 pLocation , Texture2D pTexture)
        {
            // pOrderNumber dictates which entity will be instantiated

            // 1 = Paddle (Player 1)
            // 2 = Paddle (Player 2)
            // other = Ball
            
            // Return the chosen entity
            IEntity entity;
            if (which == 1)
            {
                //entity = new Paddle(pLocation, PlayerIndex.One);

                entity = _paddleFactory.Create<Paddle>();
                ((Paddle)entity).Initalise(pLocation, PlayerIndex.One);

                ((PongEntity)entity).Content(pTexture);
            }
            else if (which  == 2) 
            {
                //entity = new Paddle(pLocation, PlayerIndex.Two);
                entity = _paddleFactory.Create<Paddle>();


                ((Paddle)entity).Initalise(pLocation, PlayerIndex.Two);

                ((PongEntity)entity).Content(pTexture);
            }

            else 
            {
                //entity = new Ball(pLocation);

                entity = _ballFactory.Create<Ball>();

                ((Ball)entity).Intalise(pLocation);

                ((PongEntity)entity).Content(pTexture);
            }

            entities.Add(entity);
            return entity;
        }
    }
}
