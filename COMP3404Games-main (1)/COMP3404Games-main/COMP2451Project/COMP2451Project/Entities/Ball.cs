using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace COMP2451Project
{
    class Ball : PongEntity
    {
        // DECLARES a random variable called rnd
        Random rnd;
        //DECLARES a vector2 variable called velocity
        Vector2 Velocity;
        //DECLARES a int variable called mSpeed
        int mSpeed;

        /// <summary>
        /// Is the constructor for the ball
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
        /// Returns the entitys texture
        /// </summary>
        /// <returns>Entity - The objects Texture</returns>
        public override Texture2D texture()
        {
            //Returns Entity
            return _Entity;
        }

        /// <summary>
        /// Used to serve the ball from the middle of the screen in a random direction
        /// </summary>
        public void serve() 
        {
            //These place the ball in the center of the screen
            //Places the ball at 450, in the x-axis
            EntityLocn.X = 450;
            //Places the ball at 450 in the y-axis
            EntityLocn.Y = 450;

            //DECLARES a float called loaction
            float Rotation;
            // Randomizes a number which detemains the angle of travel
            Rotation = (float)(Math.PI / 2 + (rnd.NextDouble() * (Math.PI / 1.5f) - Math.PI / 3));

            //Uses the sin of roatation to determain the x velocity
            Velocity.X = (float)Math.Sin(Rotation);
            // uses the cos of roatation to determain the y velocity
            Velocity.Y = (float)Math.Cos(Rotation);

            // randoms a number between 0 and 1 if it is 1 this is true
            // gives a 50 50 chance to start the ball going left or right
            if (rnd.Next(0,2) == 1) 
            {
                Velocity.X *= -1;
            }
            // changes to total velocity to go at at least 5
            Velocity *= mSpeed;

        }
        /// <summary>
        /// Used to Set Entity
        /// </summary>
        /// <param name="ballTexture">Passes the balls texture</param>
        public override void Content(Texture2D ballTexture)
        {
            //INITALIZES Entity in the parent class
            _Entity = ballTexture;
        }
        /// <summary>
        /// Updates the ball with each loop
        /// </summary>
        public override void update()
        {
            // Adds the Current X speed onto the x loction
            EntityLocn.X += Velocity.X;
            // adds the current y speed onto the y location
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
                // times the Y velocity by -1;
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
            Velocity.X *= -1;
            EntityLocn.X += Velocity.X;
        }

        /// <summary>
        /// Is used to respond when the paddle colides with the ball
        /// </summary>
        /// <param name="paddleDirection">Passes the paddles velocity</param>
        public void Colision(Vector2 paddleDirection)
        {
            // times the x velocity by -1;
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
