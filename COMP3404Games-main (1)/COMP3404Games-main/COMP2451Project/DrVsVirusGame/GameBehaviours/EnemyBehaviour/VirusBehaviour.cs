using Engine.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHORS: Lucas Brennan, Flynn Osborne & Will Eardley
/// DATE: 14/03/2022
/// </summary>
namespace DrVsVirusGame.GameBehaviours.EnemyBehaviour
{
    /// <summary>
    /// A Class that represents the Virus' Behaviour
    /// </summary>
    public class VirusBehaviour : DrVsVirusBehaviour
    {
        // DECLARE a variable to hold the speed of the Virus
        private int speed;

        /// <summary>
        /// The Default Constructor
        /// </summary>
        public VirusBehaviour() 
        {
            // SET the Virus' speed
            speed = -3;
        }

        /// <summary>
        /// A Method to responds to updates
        /// </summary>
        /// <param name="sender">The object that called the method</param>
        /// <param name="UpdateEventArgs">The Update Event Argument / Data</param>
        public override void OnUpdate(object sender, UpdateEventArgs UpdateEventArgs)
        {
            // SET _location to the entity's position
            _location = _myEntity.Position;

            // IF the virus is "moving":
            if (UpdateEventArgs.ActiveBehaviour.ToLower() == "moving") 
            {
                // UPDATE the virus' location
                _location.X += speed;
            }
        }
    }
}
