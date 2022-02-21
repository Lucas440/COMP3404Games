/// Author Lucas Brennan
/// 
/// DATE 22/01/22
/// </summary>
namespace Engine.Behaviours
{
    /// <summary>
    /// An interface for Subscribers of the update event
    /// </summary>
    public interface IUpdateListener
    {
        /// <summary>
        /// A method that is called when the sender is updated
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="UpdateEventArgs">The event argument</param>
        void OnUpdate(object sender, UpdateEventArgs args);
    }
}
