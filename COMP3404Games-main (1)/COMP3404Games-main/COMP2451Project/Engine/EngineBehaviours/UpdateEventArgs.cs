/// Author Lucas Brennan
/// 
/// DATE 22/01/22
/// </summary>
namespace Engine.Behaviours
{
    /// <summary>
    /// A Class used to represent an Event Argument for a Update
    /// </summary>
    public class UpdateEventArgs
    {
        /// <summary>
        /// The ActiveBehavior of the object calling the Event
        /// </summary>
        public string ActiveBehaviour { get; set; }
    }
}
