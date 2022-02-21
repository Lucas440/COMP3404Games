/// <summary>
/// AUTHOR: Flynn Osborne
/// DATE: 19/01/2022
/// </summary>
namespace Engine.Factories
{

    /// <summary>
    /// A class used to create new intenaces of objects
    /// </summary>
    /// <typeparam name="I">The object type</typeparam>
    public class Factory<I> : IFactory<I>, IService
    {
        /// <summary>
        /// A method used to create a new object
        /// </summary>
        /// <typeparam name="C">The object type that is being created</typeparam>
        /// <returns>An object of type C</returns>
        public I Create<C>() where C : I, new()
        {
            return new C();
        }
    }
}
