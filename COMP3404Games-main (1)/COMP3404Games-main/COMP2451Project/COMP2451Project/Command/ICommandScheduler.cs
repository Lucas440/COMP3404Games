using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project
{
    public interface ICommandScheduler
    {
        /// <summary>
        /// A method that Executes a command
        /// </summary>
        void ExecuteCommand(Action pAction);
    }
}
