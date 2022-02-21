/// <summary>
/// AUTHOR Lucas Brennan
///
/// Date 14/02/22
/// </summary>
namespace Engine.InputEvents
{
    /// <summary>
    /// An interface used to publish inputs
    /// </summary>
    public interface IInputPublisher
    {
        /// <summary>
        /// Subscribes a listener
        /// </summary>
        /// <param name="listener">The object being subscribed</param>
        void subscribe(IKeyListener listener);

        /// <summary>
        /// Removes a listener
        /// </summary>
        /// <param name="keyListener">listener being removed</param>
        void unSubscribe(IKeyListener keyListener);
    }
}
