using Microsoft.Xna.Framework.Graphics;
/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 14/02/22
/// </summary>
namespace Engine.EngineEntitys
{
    /// <summary>
    /// An interface used to represent drawable objects
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// Sets the objects texture to what is passed
        /// </summary>
        /// <param name="texture">The Object's Texture</param>
        void Content(Texture2D texture);

        /// <summary>
        /// Draws the Entity on screen
        /// </summary>
        void draw();


        /// <summary>
        /// Gets the texture of the object
        /// </summary>
        /// <returns>Returns the entity's Texture</returns>
        Texture2D texture();
    }
}
