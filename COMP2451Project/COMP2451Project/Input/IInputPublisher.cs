using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/// <summary>
/// AUTHOR Lucas Brennan
///
/// </summary>
namespace COMP3451Project.Managers.Input
{
    interface IInputPublisher
    {
        /// <summary>
        /// Subscribes a listener
        /// </summary>
        /// <param name="listener">The object being subscribed</param>
        void subscribe(IKeyListener listener);

        /// <summary>
        /// Removes a listener
        /// </summary>
        /// <param name="keyListener">listener being removed</param>
        void unSubscribe(IKeyListener keyListener);
    }
}
