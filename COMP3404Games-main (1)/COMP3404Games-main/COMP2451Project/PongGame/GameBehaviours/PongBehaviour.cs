using Engine.Behaviours;
using System;
/// AUTHOR: Lucas Brennan & Flynn Osborne
/// 
/// DATE 31/01/22
/// </summary>
namespace PongGame.Behaviours
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
