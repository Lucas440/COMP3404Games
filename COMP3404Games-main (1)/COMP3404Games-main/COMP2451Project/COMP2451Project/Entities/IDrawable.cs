﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace COMP2451Project
{
    interface IDrawable
    {
        /// <summary>
        /// Sets the objects texture to what is passed
        /// </summary>
        /// <param name="texture">The Objects Texture</param>
        void Content(Texture2D texture);

        /// <summary>
        /// Draws the Entity on screen
        /// </summary>
        void draw();


        /// <summary>
        /// Gets the texture of the object
        /// </summary>
        /// <returns>Returns the entitys Texture</returns>
        Texture2D texture();
    }
}