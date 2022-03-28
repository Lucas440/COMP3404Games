using Microsoft.Xna.Framework;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 14/02/22
/// </summary>
namespace Engine.EngineEntitys
{
    /// <summary>
    /// An interface used to represent colidable objects
    /// </summary>
    public interface ICollidable
    {
        /// <summary>
        /// Sets the boundies of the screen
        /// </summary>
        /// <param name="pWidth">The screens width</param>
        /// <param name="pHeight">the screens height</param>
        void setBoundaries(double pWidth, double pHeight);

        /// <summary>
        /// Gets the Objects HitBox
        /// </summary>
        /// <returns>The hit box</returns>
        Rectangle getHitBox();

        /// <summary>
        /// A method that responds to a colision
        /// </summary>
        /// <param name="pCollidedEntity">The Entity that it collides with</param>
        void Colision(ICollidable pCollidedEntity);
    }
}
