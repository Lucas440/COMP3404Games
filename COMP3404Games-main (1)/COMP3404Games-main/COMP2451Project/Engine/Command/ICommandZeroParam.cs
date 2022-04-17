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
    /// A Interface used to commands with Zero Paramiter
    /// </summary>
    public interface ICommandZeroParam : ICommand
    {
        /// <summary>
        /// A parameter that sets a Action
        /// </summary>
        Action SetAction { set; }
    }
}
