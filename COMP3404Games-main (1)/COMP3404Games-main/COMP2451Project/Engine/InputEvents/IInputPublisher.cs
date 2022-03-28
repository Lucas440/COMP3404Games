/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 14/02/22
/// </summary>
namespace Engine.InputEvents
{
    /// <summary>
    /// An interface used to publish inputs
    /// </summary>
    public interface IInputPublisher
    {
        /// <summary>
        /// A method that subscribes a listener
        /// </summary>
        /// <param name="listener">The object being subscribed</param>
        void subscribe(IKeyListener listener);

        /// <summary>
        /// A method that removes a listener
        /// </summary>
        /// <param name="keyListener">The listener being removed</param>
        void unSubscribe(IKeyListener keyListener);
    }
}
