using Engine.Command;
/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 22/01/22
/// </summary>
namespace Engine.EngineEntitys
{
    /// <summary>
    /// An interface that represents the internal entity
    /// </summary>
    public interface IEntityInternal
    {
        /// <summary>
        /// A property used to terminate the entity
        /// </summary>
        ICommand TerminateMe { get; set; }
        
        /// <summary>
        /// A property used to remove the entity
        /// </summary>
        ICommand RemoveMe { get; set; }
    }
}
