using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP2451Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/// <summary>
/// AUTHOR Lucas Brennan
///
/// </summary>
namespace COMP3451Project.Managers.Input
{
    interface IKeyListener
    {
        /// <summary>
        /// A method the responds to the keyboard event
        /// </summary>
        /// <param name="source">Where the event was sent from</param>
        /// <param name="args">The event argument</param>
        void OnNewInput(object source , InputEventArgs args);
    }
}
