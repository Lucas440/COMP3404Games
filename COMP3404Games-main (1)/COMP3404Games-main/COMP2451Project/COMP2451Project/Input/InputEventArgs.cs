using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// AUTHOR Lucas Brennan
///
/// </summary>
namespace COMP3451Project.Managers.Input
{
    class InputEventArgs
    {
        /// <summary>
        /// Stores the current keyboardState
        /// </summary>
        public KeyboardState keyboardState { get; set; }
    }
}
