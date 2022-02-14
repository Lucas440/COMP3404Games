using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3451.Command
{
    /// <summary>
    /// A interface that repersents commands
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// A Command to be Executed
        /// </summary>
        void Execute();
    }
}
