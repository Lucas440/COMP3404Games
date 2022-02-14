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
/// Date 14/02/22
/// </summary>
namespace COMP3451.InputEvents
{
    /// <summary>
    /// An interface used to publish events
    /// </summary>
    interface IEventPublisher
    {
        /// <summary>
        /// Updates the Event Publisher
        /// </summary>
        void update();
    }
}
