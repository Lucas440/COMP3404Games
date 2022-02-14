using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project.Command
{
    public interface ICommandOneParam<T> : ICommand
    {
        /// <summary>
        /// A parameter that sets a data type
        /// </summary>
        T SetData { set; }
        /// <summary>
        /// A parameter that sets a Action
        /// </summary>
       Action<T> SetAction { set; }
    }
}
