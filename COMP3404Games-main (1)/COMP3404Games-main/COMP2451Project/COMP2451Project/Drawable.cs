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
    public class Drawable : IDrawable
    {
        //Creates a 2D Texture Varibable called _Entity
        protected Texture2D _Entity;

        /// <summary>
        /// Sets the objects texture to what is passed
        /// </summary>
        /// <param name="texture">The Objects Texture</param>
        public virtual void Content(Texture2D texture)
        {
            _Entity = texture;
        }


        /// <summary>
        /// Draws the entity on screen
        /// </summary>
        public virtual void draw() { }


        /// <summary>
        /// Gets the texture of the object
        /// </summary>
        /// <returns>the entitys texture</returns>
        public virtual Texture2D texture()
        {
            return _Entity;
        }
    }
}
