using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace COMP2451Project
{
    class EntityManager
    {
        //A list that stores IEntitys
        List<IEntity> Entity;

        /// <summary>
        /// The Entity Managers constructor
        /// </summary>
        public EntityManager() 
        {
            //INITALIZES Entity
            Entity = new List<IEntity>();
        }

        public List<IEntity> getList() 
        {
            return Entity;
        }

        /// <summary>
        /// A Method that creates a paddle
        /// </summary>
        /// <param name="player">Stores the indext of the current player</param>
        /// <param name="texture">Stores a texture for Paddle</param>
        /// <returns></returns>
        public IEntity createPaddle(PlayerIndex player , Texture2D texture)
        {
            //Creates a new vector2 called paddleLocn
            Vector2 paddleLocn = new Vector2();

            //If the current player is 1 then this is true
            if (PlayerIndex.One == player)
            {
                // Stores the xPosition as 0
                paddleLocn.X = 0;
                // Stores the yPosition as 50
                paddleLocn.Y = 50;
            }
            // if the current player is player 2 then this is true
            else if (PlayerIndex.Two == player) 
            {
                // Stores the current xPosition as 850
                paddleLocn.X = 850;
                // Stores the current yPosition as 50
                paddleLocn.Y = 50;
            }
            //Defults the value in the middle of the screen
            else 
            {
                //Stores the X and Y Position at 450
                paddleLocn.X = 450;
                paddleLocn.Y = 450;
            }

            //INITALIZES a new paddle passing the location and the player controling it
            IEntity Paddle = new Paddle(paddleLocn , player);

            //calles content in paddle and passes the texture
            ((IDrawable)Paddle).Content(texture);

            // Adds the paddle to the entity list
            Entity.Add(Paddle);

            //Returns the paddle
            return Paddle;
        }

       /// <summary>
       /// A method that creates a ball object
       /// </summary>
       /// <param name="texture">The Texture of the ball</param>
       /// <returns>The ball object</returns>
        public IEntity createBall(Texture2D texture) 
        {
            // INITALIZES a new Vector2 called ballLocn
            Vector2 ballLocn = new Vector2();

            //Stores the x and y Position at 450 (The center of the screen)
            ballLocn.X = 450;
            ballLocn.Y = 450;

            //Creates a new ball Entity passing the ballLocn
            IEntity ball = new Ball(ballLocn);

            //Calls the content method passing the textrue
            ((IDrawable)ball).Content(texture);

            //Adds the ball to the list
            Entity.Add(ball);

            //Returns the ball object  
            return ball;
        }
        /// <summary>
        /// Updates the EntityManager
        /// </summary>
        public void update() {}
    }
}
