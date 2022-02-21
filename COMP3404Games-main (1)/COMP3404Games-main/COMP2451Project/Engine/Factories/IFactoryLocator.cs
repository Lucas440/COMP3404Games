/// <summary>
/// AUTHOR: Flynn Osborne
/// DATE: 19/01/2022
/// </summary>
namespace Engine.Factories
{
    /// <summary>
    /// An interface used to get a Service
    /// </summary>
    public interface IFactoryLocator
    {
        /// <summary>
        /// A method that gets the required service
        /// </summary>
        /// <typeparam name="T">The type of serive required</typeparam>
        /// <returns>The Service required as type T</returns>
        IService Get<T>() where T : class;
    }
}
