using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author Lucas Brennan
/// 
///DATE 22/01/22
/// </summary>
namespace COMP2451Project
{
    /// <summary>
    /// A class that schedules commands
    /// </summary>
    public class CommandScheduler : ICommandScheduler
    {
        /// <summary>
        /// A method used to Execute a command
        /// </summary>
        /// <param name="pAction">The action being Executed</param>
        public void ExecuteCommand(Action pAction) 
        {
            //Invokes the action
            pAction.Invoke();
        }
    }
}
