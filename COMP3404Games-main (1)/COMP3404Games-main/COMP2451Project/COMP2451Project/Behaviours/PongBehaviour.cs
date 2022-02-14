using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// AUTHOR: Lucas Brennan & Flynn Osborne
/// 
/// DATE 31/01/22
/// </summary>
namespace COMP3451.Behaviours
{
    /// <summary>
    /// A class that represents the Behavor of a PongEntity
    /// </summary>
    class PongBehaviour : Behaviour
    {
        /// <summary>
        /// A method that is called when the sender is updated
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="UpdateEventArgs">The event argument</param>
        public override void OnUpdate(Object sender, UpdateEventArgs UpdateEventArgs) { }

        /// <summary>
        /// A method that is called when an entity is collided with
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="UpdateEventArgs">The event argument</param>
        public override void OnCollision(Object sender, UpdateEventArgs UpdateEventArgs) { }
    }
}
