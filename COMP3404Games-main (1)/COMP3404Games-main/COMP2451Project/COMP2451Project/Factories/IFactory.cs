using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHOR: Flynn Osborne
/// DATE: 19/01/2022
/// </summary>
namespace COMP3451.Factories
{
    /// <summary>
    /// An interface used to create new intences of objects
    /// </summary>
    /// <typeparam name="I">The type of object being created</typeparam>
    public interface IFactory<I> : IService
    {
        /// <summary>
        /// A method that returns a new object of a specifed type
        /// </summary>
        /// <typeparam name="C">The object type Specifed</typeparam>
        /// <returns>A new object of type C</returns>
        I Create<C>() where C : I, new();
    }
}
