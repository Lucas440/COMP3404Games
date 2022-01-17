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
    abstract class Entity : IEntity
    {

        //Creates a vector called ballLocn
        protected Vector2 EntityLocn;

        /// <summary>
        /// Updates the entity on each loop
        /// </summary>
        public virtual void update() { }

        /// <summary>
        /// Returns the objects Position
        /// </summary>
        /// <returns>The entity current position</returns>
        public virtual Vector2 position()
        {
            return EntityLocn;
        }
    }
}
