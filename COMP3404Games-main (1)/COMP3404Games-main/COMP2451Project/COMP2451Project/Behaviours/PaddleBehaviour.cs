using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author Lucas Brennan
/// 
/// DATE 22/01/22
/// </summary>
namespace COMP2451Project.Behaviours
{
    class PaddleBehaviour : PongBehaviour, IUpdateListener
    {
        /// <summary>
        /// The Defualt constructor for PaddleBehaviour
        /// </summary>
        public PaddleBehaviour() 
        {
            //INITALISES _velocity
            _velocity = new Vector2();
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
        }
    }
}
