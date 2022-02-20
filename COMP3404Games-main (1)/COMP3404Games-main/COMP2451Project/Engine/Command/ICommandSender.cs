using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 22/01/22
/// </summary>
namespace Engine.Command
{
    /// <summary>
    /// An interface used to Send commands
    /// </summary>
    public interface ICommandSender
    {
        /// <summary>
        /// A property that stores Actions to be executed
        /// </summary>
        Action<ICommand> ScheduleCommand { get; set; }
    }
}
