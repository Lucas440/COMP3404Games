/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 14/02/22
/// </summary>
namespace Engine.InputEvents
{
    /// <summary>
    /// An interface used to represent an object that publishes clicks
    /// </summary>
    public interface IClickPublisher
    {
        /// <summary>
        /// A method that subscribes a listener to an input publisher
        /// </summary>
        /// <param name="listener">The object being subscribed</param>
        void subscribe(IClickListener listener);

        /// <summary>
        /// A method that unsubscribes a listener from an input publisher
        /// </summary>
        /// <param name="keyListener">The listener being removed</param>
        void unSubscribe(IClickListener keyListener);
    }
}
