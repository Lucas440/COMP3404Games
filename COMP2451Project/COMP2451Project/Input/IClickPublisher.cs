using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHOR Lucas Brennan
///
/// </summary>
namespace COMP3451Project.Managers.Input
{
    interface IClickPublisher
    {
        /// <summary>
        /// Subscribes a listener
        /// </summary>
        /// <param name="listener">The object being subscribed</param>
        void subscribe(IClickListener listener);

        /// <summary>
        /// Removes a listener
        /// </summary>
        /// <param name="keyListener">listener being removed</param>
        void unSubscribe(IClickListener keyListener);
    }
}
