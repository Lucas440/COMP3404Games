/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 14/02/22
/// </summary>
namespace Engine.InputEvents
{
    /// <summary>
    /// An interface used to represent a object that listens for clicks
    /// </summary>
    public interface IClickListener
    {
        /// <summary>
        /// A method that responds to a mouseClick
        /// </summary>
        /// <param name="sorce">The source of the event</param>
        /// <param name="args">The event argument</param>
        void OnNewClick(object sorce, ClickEventArgs args);
    }
}
