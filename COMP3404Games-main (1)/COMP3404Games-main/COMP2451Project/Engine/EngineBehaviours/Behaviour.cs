using Engine.EngineEntitys;
using Microsoft.Xna.Framework;
using System;
///<summary>
/// AUTHORS: Lucas Brennan & Flynn Osborne
/// DATE: 07/02/2022
/// </summary>
namespace Engine.Behaviours
{
    /// <summary>
    /// A class to represent the behaviour of objects
    /// </summary>
    public class Behaviour : IBehaviour
    {
        // DECLARES a Vector2 called _velocity
        protected Vector2 _velocity;

        // DECLARES a vector called _location
        protected Vector2 _location;

        /// <summary>
        /// A property that returns an entity's velocity
        /// </summary>
        public virtual Vector2 Velocity { get => _velocity; }

        /// <summary>
        /// A property that returns an entity's location
        /// </summary>
        public virtual Vector2 Location { get => _location; }

        /// <summary>
        /// A property that stores an IEntity
        /// </summary>
        public IEntity _myEntity { set; get; }

        /// <summary>
        /// A method that is called when the sender is updated
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="UpdateEventArgs">The event argument</param>
        public virtual void OnUpdate(Object sender, UpdateEventArgs UpdateEventArgs) { }

        /// <summary>
        /// A method that is called when an entity is collided with
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="UpdateEventArgs">The event argument</param>
        public virtual void OnCollision(Object sender, UpdateEventArgs UpdateEventArgs) { }
    }
}
