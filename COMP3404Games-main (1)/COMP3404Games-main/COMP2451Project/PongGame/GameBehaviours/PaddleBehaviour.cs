using Engine.Behaviours;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHOR: Lucas Brennan & Flynn Osborne
/// 
/// DATE: 07/02/2022
/// </summary>
namespace PongGame.Behaviours
{
    /// <summary>
    /// A class used to represent behaviours of paddle objects
    /// </summary>
    class PaddleBehaviour : PongBehaviour, IUpdateListener
    {
        // A variable to hold the height limit
        double _height;

        /// <summary>
        /// The Default constructor for PaddleBehaviour
        /// </summary>
        public PaddleBehaviour() 
        {
            // INITALISES _velocity
            _velocity = new Vector2();

            // SETS the height limit
            _height = 760;
        }

        /// <summary>
        /// A method that is called when the sender is updated
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="UpdateEventArgs">The event argument</param>
        public override void OnUpdate(Object sender , UpdateEventArgs UpdateEventArgs) 
        {
            //If the ActiveBehaviour is "up" then this is true
            if (UpdateEventArgs.ActiveBehaviour.ToLower() == "up") 
            {
                //Sets the Y velocity to -1
                _velocity.Y = -1;
            }
            //If the ActiveBehaviour is "down" then this is true
            else if (UpdateEventArgs.ActiveBehaviour.ToLower() == "down") 
            {
                //Sets the Y velocity to 1
                _velocity.Y = 1;
            }
            //If the ActiveBehaviour is "stopped" then this is true
            else if (UpdateEventArgs.ActiveBehaviour.ToLower() == "stopped") 
            {
                //Sets the Y velocity to 0
                _velocity.Y = 0;
            }

            // Update the paddle's location
            _location.Y += _velocity.Y * 5;

            // This triggers if the paddle reaches the screen's boundaries
            if (_location.Y < 0)
            {
                // Stop the paddle from moving off the top of the screen
                _location.Y = 0;
            }
            else if (_location.Y > _height)
            {
                // Stop the paddle from moving off the bottom of the screen
                _location.Y = (float)_height;
            }
            
        }

        /// <summary>
        /// The method called when the paddle collides with an object
        /// </summary>
        /// <param name="sender">The object that triggered that method</param>
        /// <param name="UpdateEventArgs">The event arguments</param>
        public override void OnCollision(object sender, UpdateEventArgs UpdateEventArgs)
        {

        }
    }
}
