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
    // AUTHOR: Flynn Osborne
    // DATE: 19/01/2022

    public interface IFactory<I> : IService
    {
        I Create<C>() where C : I, new();
    }
}
