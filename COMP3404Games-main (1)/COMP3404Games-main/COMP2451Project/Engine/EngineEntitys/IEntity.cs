using Microsoft.Xna.Framework;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 22/01/22
/// </summary>
namespace Engine.EngineEntitys
{
    /// <summary>
    /// An interface used to repesent entitys
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Updates the Entity on each loop
        /// </summary>
        void update();

        /// <summary>
        /// Returns the objects Position
        /// </summary>
        /// <returns>The entity current position</returns>
        Vector2 position();
        /// <summary>
        /// A property that returns the state the program is in as a string
        /// </summary>
        string StateText { get; set; }
    }
}
