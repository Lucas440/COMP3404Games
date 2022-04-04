/// <summary>
/// AUTHOR: Flynn Osborne
/// DATE: 19/01/2022
/// </summary>
namespace Engine.Factories
{
    /// <summary>
    /// An interface used to create new instances of objects
    /// </summary>
    /// <typeparam name="I">The type of object being created</typeparam>
    public interface IFactory<I> : IService
    {
        /// <summary>
        /// A method that returns a new object of a specifed type
        /// </summary>
        /// <typeparam name="C">The object type specifed</typeparam>
        /// <returns>A new object of type C</returns>
        I Create<C>() where C : I, new();
    }
}
