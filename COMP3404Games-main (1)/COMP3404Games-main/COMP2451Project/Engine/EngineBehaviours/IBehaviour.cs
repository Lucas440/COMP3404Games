using Microsoft.Xna.Framework;
using System;
/// <summary>
/// AUTHOR: Lucas Brennan & Flynn Osborne
/// DATE: 07/02/22
/// </summary>
namespace Engine.Behaviours
{
    /// <summary>
    /// An interface used to represent the behaviour of objects
    /// </summary>
    public interface IBehaviour
    {
        /// <summary>
        /// A property which returns an entity's velocity
        /// </summary>
        Vector2 Velocity { get; }

        /// <summary>
        /// A property that returns an entity's location
        /// </summary>
        Vector2 Location { get; }

        /// <summary>
        /// A method that is called when the sender is updated
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="UpdateEventArgs">The event argument</param>
        void OnUpdate(Object sender, UpdateEventArgs UpdateEventArgs);

        /// <summary>
        /// A method that is called when an entity is collided with
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="UpdateEventArgs">The event argument</param>
        void OnCollision(Object sender, UpdateEventArgs CollisionEventArgs);
    }
}
