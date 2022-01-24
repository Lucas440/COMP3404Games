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
    public class Behaviour: IBehaviour
    {
        //DECLARES a Vector2 called _velocity
        protected Vector2 _velocity;
        /// <summary>
        /// A property that returns a velocity
        /// </summary>
        public virtual Vector2 Velocity { get => _velocity; }
        /// <summary>
        /// A property that stores a IEntity
        /// </summary>
        public IEntity _myEntity { set; get; }
        /// <summary>
        /// A method that is called when the sender is updated
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="UpdateEventArgs">The event argument</param>
        public virtual void OnUpdate(Object sender, UpdateEventArgs UpdateEventArgs) { }
    }
}
