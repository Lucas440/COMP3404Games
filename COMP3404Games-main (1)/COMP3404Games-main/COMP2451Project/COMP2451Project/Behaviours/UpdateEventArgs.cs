using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// Author Lucas Brennan
/// 
/// DATE 22/01/22
/// </summary>
namespace COMP2451Project.Behaviours
{
    /// <summary>
    /// A Class used to represent an Event Argument
    /// </summary>
    public class UpdateEventArgs
    {
        /// <summary>
        /// The ActiveBehavior of the object calling the Event
        /// </summary>
        public string ActiveBehaviour { get; set; }
    }
}
