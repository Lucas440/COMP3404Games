using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace COMP2451Project
{
    // AUTHOR: Lucas Brennan
    // DATE: 24/01/2022
    class Ball : PongEntity
    {
        // DECLARES a random variable called rnd
        Random rnd;
        //DECLARES a vector2 variable called velocity
        Vector2 Velocity;
        //DECLARES a int variable called mSpeed
        int mSpeed;

        /// <summary>
        /// This is the constructor for the ball
        /// </summary>
        /// <param name="ballVector"> Is used to store the starting location for the ball </param>
        public Ball(Vector2 ballVector) 
        {
            //INITALIZES objectType in the parent class
            objectType = "square";
            //INITALIZES EntityLocn in the parent class
            EntityLocn = ballVector;
            //INITALIZES rnd
            rnd = new Random();
            // INITALIZES mSpeed
            mSpeed = 5;

        }


        /// <summary>
        /// Returns the entity's texture
        /// </summary>
        /// <returns>_Entity - The object's Texture</returns>
        public override Texture2D texture()
        {
            //Returns _Entity
            return _Entity;
        }

        /// <summary>
        /// Used to serve the ball from the middle of the screen in a random direction
        /// </summary>
        public void serve() 
        {
            // These place the ball in the center of the screen
            // Places the ball at 450, in the x-axis
            EntityLocn.X = 450;
            // Places the ball at 450 in the y-axis
            EntityLocn.Y = 450;

            // DECLARES a float called Rotation
            float Rotation;
            // Randomizes a number which determines the angle of travel
            Rotation = (float)(Math.PI / 2 + (rnd.NextDouble() * (Math.PI / 1.5f) - Math.PI / 3));

            // Uses the sin of rotation to determine the x velocity
            Velocity.X = (float)Math.Sin(Rotation);
            // uses the cos of rotation to determine the y velocity
            Velocity.Y = (float)Math.Cos(Rotation);

            // Randomly generates a number between 0 and 1. If it is 1, then this is true:
            if (rnd.Next(0,2) == 1) 
            {
                // The ball will move to the left
                Velocity.X *= -1;
            }
            // Multiplies the ball's velocity by the set speed
            Velocity *= mSpeed;

        }
        /// <summary>
        /// Used to Set _Entity
        /// </summary>
        /// <param name="ballTexture">Passes the balls texture</param>
        public override void Content(Texture2D ballTexture)
        {
            //INITALIZES _Entity in the parent class
            _Entity = ballTexture;
        }
        /// <summary>
        /// Updates the ball with each loop
        /// </summary>
        public override void update()
        {
            // Moves the ball along the x-axis by the ball's x velocity
            EntityLocn.X += Velocity.X;
            // Moves the ball along the y-axis by the ball's y velocity
            EntityLocn.Y += Velocity.Y;
            // calls update in the parent class
            base.update();
            // calls check wall Colision
            checkWallColision();
            
        }
        /// <summary>
        /// Checks the colision between the wall and the Ball
        /// </summary>
        public override void checkWallColision() 
        {
            // if the ball's y position is less than 0 or greater than the screens height then this is true
            if (EntityLocn.Y < 0 || EntityLocn.Y > Height - 45) 
            {
                // multiplies the Y velocity by -1, reversing the vertical direction of the ball
                Velocity.Y *= -1;
            }
            // if the ball's x position is less than 0 or greater than the screens width then this is true
            if (EntityLocn.X < 0 || EntityLocn.X > Width - 45) 
            {
                // calls the serve method
                serve();
            }
        }

        /// <summary>
        /// A method that responds when coliding with an object
        /// </summary>
        public override void colision() 
        {
            // Reverse the horizontal direction of the ball
            Velocity.X *= -1;
            
            // Update the ball's location
            EntityLocn.X += Velocity.X;
        }

        /// <summary>
        /// Is used to respond when the paddle colides with the ball
        /// </summary>
        /// <param name="paddleDirection">Passes the paddles velocity</param>
        public void Colision(Vector2 paddleDirection)
        {
            // multiply the x velocity by -1;
            Velocity.X *= -1;

            // if the paddle's y direction is greater than 0 this is true
            if (paddleDirection.Y > 0)
            {
                // Adds the speed of the paddle plus 1.5 to the y Velocity
                Velocity.Y += (paddleDirection.Y + 1.5F);
            }
            // else if the paddles y direction is less than 0 this is true
            else if (paddleDirection.Y < 0) 
            {
                // subbtracts the paddles y direction plus 1.5 from the y velocity
                Velocity.Y -= (paddleDirection.Y + 1.5F);
            }
        }
    }
}
