using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace COMP2451Project
{
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
