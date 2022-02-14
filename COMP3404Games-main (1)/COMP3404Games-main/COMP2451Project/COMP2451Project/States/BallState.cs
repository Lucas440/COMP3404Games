using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP3451.Behaviours;

namespace COMP3451.States
{
    // AUTHOR: Flynn Osborne
    // DATE: 31/01/2022

    public class BallState : PongState
    {
        /// <summary>
        /// The method used to update the ball's state
        /// </summary>
        public override void Update()
        {
            // Triggers the ball's update behaviour
            _behaviour.OnUpdate(_entity, new Behaviours.UpdateEventArgs() { ActiveBehaviour = "" });
        }

        /// <summary>
        /// The method triggered when the ball has a collision
        /// </summary>
        public override void Collide()
        {
            // Triggers the ball's collision behaviour
            _behaviour.OnCollision(_entity, new Behaviours.UpdateEventArgs() { ActiveBehaviour = "" });
        }
    }
}
