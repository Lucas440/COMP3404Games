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
    abstract class Collidable
    {

        //DECLARES a doible that stores the screens width
        protected double Width;
        //DECLARES a double that store the screens Height
        protected double Height;

        //DECLARES a retangle called hitBox
        protected Rectangle hitBox;

        ///<summary>
        /// Sets the boundies of the screen
        /// </summary>
        /// <param name="width">The screens width</param>
        /// <param name="height">The screens Height</param>
        public void setBoundaries(double pWidth, double pHeight)
        {
            Width = pWidth;
            Height = pHeight;
        }

        public Rectangle getHitBox()
        {
            return hitBox;
        }

        /// <summary>
        /// A method that responds to a colision
        /// </summary>
        public virtual void colision() { }
    }
}
