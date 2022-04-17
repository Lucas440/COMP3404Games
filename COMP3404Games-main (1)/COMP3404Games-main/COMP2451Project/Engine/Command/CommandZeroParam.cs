using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 17/04/22
/// </summary>
namespace Engine.Command
{
    /// <summary>
    /// A Class used for commands with zero paramiter
    /// </summary>
    public class CommandZeroParam : ICommandZeroParam
    {
        //the action that will be invoked
        private Action _action;
        /// <summary>
        /// A parameter that sets a Action
        /// </summary>
        public Action SetAction { set { _action = value; } }

        public void Execute()
        {
            //Inovker the command
            _action.Invoke();
        }
    }
}
