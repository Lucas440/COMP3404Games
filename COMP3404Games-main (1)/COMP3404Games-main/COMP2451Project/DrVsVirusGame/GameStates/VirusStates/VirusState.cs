using Engine.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Authors Lucas Brennan, Flynn Osborne & Will Eardley
/// 
/// Date 14/03/2022
/// </summary>
namespace DrVsVirusGame.GameStates.VirusStates
{
    public class VirusState : DrVsVirusState
    {
        //DECLARE a new string called _identifier
        private string _identifier;

        /// <summary>
        /// The recommended constructor for VirusState
        /// </summary>
        /// <param name="pIdentifier">The Defult identifier string</param>
        public VirusState(string pIdentifier) 
        {
            _identifier = pIdentifier;
        }

        /// <summary>
        /// A Method used to respond to collision
        /// </summary>
        public override void Collide()
        {
            //Triggers _behaviour OnCollision method
            Behaviour.OnCollision(_entity, new UpdateEventArgs {ActiveBehaviour = ""});
        }
        /// <summary>
        /// A Method used to update the state
        /// </summary>
        public override void Update()
        {
            //triggers _behaviours OnUpdate Method
            Behaviour.OnUpdate(_entity , new UpdateEventArgs {ActiveBehaviour = _identifier });
        }
    }
}
