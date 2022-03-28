using Microsoft.Xna.Framework;
/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 28/03/22
/// </summary>
namespace Engine.EngineEntitys
{
    /// <summary>
    /// An interface used to represent colidable objects
    /// </summary>
    public interface ICollidable
    {
        /// <summary>
        /// A method that sets the boundaries of the screen
        /// </summary>
        /// <param name="pWidth">The screen's width</param>
        /// <param name="pHeight">the screen's height</param>
        void setBoundaries(double pWidth, double pHeight);

        /// <summary>
        /// GETS the object's HitBox
        /// </summary>
        /// <returns>The hitbox</returns>
        Rectangle getHitBox();

        /// <summary>
        /// A method that responds to a colision
        /// </summary>
        /// <param name="pCollidable">The entity being collided with</param>
        void colision(ICollidable pCollidable);
    }
}
