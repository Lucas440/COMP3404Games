using Engine.Command;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 22/01/22
/// </summary>
namespace Engine.EngineEntitys
{
    /// <summary>
    /// An interface that represents the internal Entity
    /// </summary>
    public interface IEntityInternal
    {
        /// <summary>
        /// A Propertiy used to terminate the entity
        /// </summary>
        ICommand TerminateMe { get; set; }
        /// <summary>
        /// A Propertity used to remove the entity
        /// </summary>
        ICommand RemoveMe { get; set; }
    }
}
