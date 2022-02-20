using Engine.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame.States
{
    // AUTHOR: Flynn Osborne
    // DATE: 07/02/2022

    public class PaddleState : PongState
    {
        // A variable to identify the state
        private string identifier;

        /// <summary>
        /// The constructor for the paddle's states
        /// </summary>
        /// <param name="pIdentifier">A string used to identify the state</param>
        public PaddleState(string pIdentifier)
        {
            // SETS the identity of the state
            identifier = pIdentifier;
        }

        /// <summary>
        /// The method used to update the state
        /// </summary>
        public override void Update()
        {
            // Calls the behaviour's update method
            // The identifier is used to decide the behaviour's actions
            _behaviour.OnUpdate(_entity, new UpdateEventArgs() { ActiveBehaviour = identifier });
        }

        /// <summary>
        /// The method triggered when the paddle collides
        /// </summary>
        public override void Collide()
        {
            // Triggers the state's collision behaviour
            _behaviour.OnCollision(_entity, new UpdateEventArgs() { ActiveBehaviour = "" });
        }
    }
}
