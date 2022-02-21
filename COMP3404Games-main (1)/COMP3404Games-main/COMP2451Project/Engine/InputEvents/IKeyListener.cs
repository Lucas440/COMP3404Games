/// <summary>
/// AUTHOR Lucas Brennan
///
/// Date 14/02/22
/// </summary>
namespace Engine.InputEvents
{
    /// <summary>
    /// An interface used to Listen for Key inputs
    /// </summary>
    public interface IKeyListener
    {
        /// <summary>
        /// A method the responds to the keyboard event
        /// </summary>
        /// <param name="source">Where the event was sent from</param>
        /// <param name="args">The event argument</param>
        void OnNewInput(object source, InputEventArgs args);
    }
}
