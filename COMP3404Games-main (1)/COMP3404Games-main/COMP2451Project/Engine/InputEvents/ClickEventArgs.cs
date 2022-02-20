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
    ///  A class used to send data during a click event
    /// </summary>
    public class ClickEventArgs
    {
        //A MouseState paramiter that stores the data being sent
        public MouseState mouseState { get; set; }
    }
}
