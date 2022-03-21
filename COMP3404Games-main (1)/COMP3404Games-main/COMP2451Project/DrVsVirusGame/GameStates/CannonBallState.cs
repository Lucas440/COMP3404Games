using Engine.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 21/03/22
/// </summary>
namespace DrVsVirusGame.GameStates
{
    /// <summary>
    /// A Class that represents the cannon balls state
    /// </summary>
    public class CannonBallState : DrVsVirusState
    {
        /// <summary>
        /// A method that updates the state
        /// </summary>
        public override void Update()
        {
            //Calls OnUpdate method for Behaviour
            Behaviour.OnUpdate(_entity , new UpdateEventArgs() { ActiveBehaviour = "moving" });
        }
    }
}
