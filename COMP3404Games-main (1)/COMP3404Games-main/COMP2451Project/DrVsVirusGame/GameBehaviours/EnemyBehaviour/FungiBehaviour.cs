using Engine.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 21/04/22
/// </summary>
namespace DrVsVirusGame.GameBehaviours.EnemyBehaviour
{
    /// <summary>
    /// A Class that represents the FungiBehaviour
    /// </summary>
    public class FungiBehaviour: DrVsVirusBehaviour
    {
        // DECLARE a variable to hold the speed of the Virus
        private int speed;

        /// <summary>
        /// The Default Constructor
        /// </summary>
        public FungiBehaviour()
        {
            // SET the Fungi's speed
            speed = -1;
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

            // IF the Fungi is "moving":
            if (UpdateEventArgs.ActiveBehaviour.ToLower() == "moving")
            {
                // UPDATE the Fungi's location
                _location.X += speed;
            }
        }
    }
}
