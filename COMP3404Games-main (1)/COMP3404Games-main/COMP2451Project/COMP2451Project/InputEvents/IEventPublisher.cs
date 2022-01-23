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
    interface IEventPublisher
    {
        /// <summary>
        /// Updates the Event Publisher
        /// </summary>
        void update();
    }
}
