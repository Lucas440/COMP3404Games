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
    public class InputEventArgs
    {
        /// <summary>
        /// Stores the current keyboardState
        /// </summary>
        public KeyboardState keyboardState { get; set; }
    }
}
