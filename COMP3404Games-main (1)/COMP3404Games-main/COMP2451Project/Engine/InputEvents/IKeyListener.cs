/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 14/02/22
/// </summary>
namespace Engine.InputEvents
{
    /// <summary>
    /// An interface used to listen for Keyboard inputs
    /// </summary>
    public interface IKeyListener
    {
        /// <summary>
        /// A method that responds to keyboard events
        /// </summary>
        /// <param name="source">Where the event was sent from</param>
        /// <param name="args">The event argument</param>
        void OnNewInput(object source, InputEventArgs args);
    }
}
