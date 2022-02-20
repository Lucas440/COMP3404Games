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
namespace Engine.InputEvents
{
    /// <summary>
    /// A Event Argument used to send data during an input event
    /// </summary>
    public class InputEventArgs
    {
        /// <summary>
        /// Stores the current keyboardState
        /// </summary>
        public KeyboardState keyboardState { get; set; }
    }
}
