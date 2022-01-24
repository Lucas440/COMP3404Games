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
/// Date 22/01/22
/// </summary>
namespace COMP2451Project
{
    /// <summary>
    /// An interface used to repesent entitys
    /// </summary>
    public interface IEntity
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
