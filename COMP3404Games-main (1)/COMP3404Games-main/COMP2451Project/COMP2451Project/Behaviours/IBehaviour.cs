using Microsoft.Xna.Framework;
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
    public interface IBehaviour
    {
        /// <summary>
        /// A Property which returns a Velocity
        /// </summary>
        Vector2 Velocity { get; }
        /// <summary>
        /// A method that is called when the sender is updated
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="UpdateEventArgs">The event argument</param>
        void OnUpdate(Object sender, UpdateEventArgs UpdateEventArgs);
    }
}
