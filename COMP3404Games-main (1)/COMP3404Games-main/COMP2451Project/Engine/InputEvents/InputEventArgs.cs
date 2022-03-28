using Microsoft.Xna.Framework.Input;

/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 14/02/22
/// </summary>
namespace Engine.InputEvents
{
    /// <summary>
    /// An Event Argument used to send data during an input event
    /// </summary>
    public class InputEventArgs
    {
        /// <summary>
        /// A property that stores the current keyboardState
        /// </summary>
        public KeyboardState keyboardState { get; set; }
    }
}
