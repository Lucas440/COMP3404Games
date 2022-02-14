using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 14/02/22
/// </summary>
namespace COMP3451.Entities
{
    /// <summary>
    /// An interface used to represent colidable objects
    /// </summary>
    interface ICollidable
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
        void colision();
    }
}
