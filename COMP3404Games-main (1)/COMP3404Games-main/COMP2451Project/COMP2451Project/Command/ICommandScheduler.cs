using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author Lucas Brennan
/// 
/// DATE 22/01/22
/// </summary>
namespace COMP3451.Command
{
    /// <summary>
    /// An interface that Schedules commands
    /// </summary>
    public interface ICommandScheduler
    {
        /// <summary>
        /// A method that Executes a command
        /// </summary>
        void ExecuteCommand(ICommand pCommand);
        /// <summary>
        /// A method used to update the ICommandScheduler
        /// </summary>
        void Update();
    }
}
