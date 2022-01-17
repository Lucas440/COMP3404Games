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
    interface IEntity
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
    }
}
