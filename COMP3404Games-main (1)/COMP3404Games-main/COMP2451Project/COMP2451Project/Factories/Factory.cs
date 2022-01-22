using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project
{
    // AUTHOR: Flynn Osborne
    // DATE: 19/01/2022

    public class Factory<I> : IFactory<I>, IService
    {
        // Creates an instance of the class 
        public I Create<C>() where C : I, new()
        {
            return new C();
        }
    }
}
