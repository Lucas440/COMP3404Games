using Microsoft.Xna.Framework;
/// <summary>
/// AUTHOR: Lucas Brennan
/// 
/// DATE: 22/01/22
/// </summary>
namespace Engine.EngineEntitys
{
    /// <summary>
    /// An interface used to repesent entities
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// A method that updates the entity on each loop
        /// </summary>
        void update();

        /// <summary>
        /// A property to return the object's Position
        /// </summary>
        Vector2 Position { get; }

        /// <summary>
        /// A property that sets and returns the state the program is in as a string
        /// </summary>
        string StateText { get; set; }
    }
}
