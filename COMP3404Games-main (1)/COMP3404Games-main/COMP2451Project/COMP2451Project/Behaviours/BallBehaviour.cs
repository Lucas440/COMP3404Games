using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3451.Behaviours
{
    /// <summary>
    /// AUTHOR: Flynn Osborne & Lucas Brennan
    /// DATE: 07/02/2022
    /// </summary>
    class BallBehaviour: PongBehaviour, IUpdateListener
    {
        // A property to get the ball's velocity
        public override Vector2 Velocity { get => _velocity; }

        // A property to get the ball's location
        public override Vector2 Location { get => _location; }

        // DECLARES a int variable called mSpeed
        int mSpeed;

        // DECLARES a variable to hold the screen's height
        double _height;

        /// <summary>
        /// The constructor for BallBehaviour
        /// </summary>
        public BallBehaviour()
        {
            // INITIALISE the ball's velocity
            _velocity = new Vector2();


            // INITALIZES mSpeed
            mSpeed = 5;

            // SET the height limit
            _height = 850;
        }

        /// <summary>
        /// The method called when the ball is updated
        /// </summary>
        /// <param name="sender">The object that triggered the method</param>
        /// <param name="UpdateEventArgs">The event arguments</param>
        public override void OnUpdate(Object sender, UpdateEventArgs UpdateEventArgs) 
        {
            // Moves the ball along the x-axis by the ball's x velocity
            //EntityLocn.X += _behaviour.Velocity.X;
            _location.X += _velocity.X * mSpeed;

            // Moves the ball along the y-axis by the ball's y velocity
            _location.Y += _velocity.Y * mSpeed;

            // This activates when the 'serve' behavior is called:
            if (UpdateEventArgs.ActiveBehaviour.ToLower() == "serve")
            {
                // DECLARES a float called Rotation
                float Rotation;

                // DECLARES a random variable called rnd
                Random rnd = new Random();

                // These place the ball in the center of the screen
                // Places the ball at 450, in the x-axis
                _location.X = 450;
                // Places the ball at 450 in the y-axis
                _location.Y = 450;

                // Randomizes a number which determines the angle of travel
                Rotation = (float)(Math.PI / 2 + (rnd.NextDouble() * (Math.PI / 1.5f) - Math.PI / 3));

                // Uses the sin of rotation to determine the x velocity
                _velocity.X = (float)Math.Sin(Rotation);
                // uses the cos of rotation to determine the y velocity
                _velocity.Y = (float)Math.Cos(Rotation);

                // Randomly generates a number between 0 and 1. If it is 1, then this is true:
                if (rnd.Next(0, 2) == 1)
                {
                    // The ball will move to the left
                    _velocity.X *= -1;
                }
            }

            // if the ball's y position is less than 0 or greater than the screens height then this is true
            if (_location.Y < 0)
            {
                // multiplies the Y velocity by -1, reversing the vertical direction of the ball
                _velocity.Y *= -1;

                // Update the ball's location
                _location.Y += _velocity.Y;
            }
            else if (_location.Y > _height)
            {
                // multiplies the Y velocity by -1, reversing the vertical direction of the ball
                _velocity.Y *= -1;

                // Update the ball's location
                _location.Y += _velocity.Y;
            }

        }

        /// <summary>
        /// The method called when the ball collides with an object
        /// </summary>
        /// <param name="sender">The object that triggered that method</param>
        /// <param name="UpdateEventArgs">The event arguments</param>
        public override void OnCollision(object sender, UpdateEventArgs UpdateEventArgs)
        {
            // Reverse the horizontal direction of the ball
            _velocity.X *= -1;

            // Update the ball's location
            _location.X += _velocity.X;
        }
    }
}
