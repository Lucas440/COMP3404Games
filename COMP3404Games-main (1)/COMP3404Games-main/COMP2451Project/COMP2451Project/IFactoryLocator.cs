using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project
{
    // AUTHOR: Flynn Osborne
    // DATE: 19/01/2022

    public interface IFactoryLocator
    {
        IService Get<T>() where T : class;
    }
}
