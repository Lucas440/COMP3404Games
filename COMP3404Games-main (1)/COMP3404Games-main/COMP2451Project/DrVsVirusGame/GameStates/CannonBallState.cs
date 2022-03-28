using Engine.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 21/03/22
/// </summary>
namespace DrVsVirusGame.GameStates
{
    /// <summary>
    /// A Class that represents the cannonball's state
    /// </summary>
    public class CannonBallState : DrVsVirusState
    {
        /// <summary>
        /// A method that updates the cannonball's state
        /// </summary>
        public override void Update()
        {
            // CALLS OnUpdate method in Behaviour
            Behaviour.OnUpdate(_entity , new UpdateEventArgs() { ActiveBehaviour = "moving" });
        }
    }
}
