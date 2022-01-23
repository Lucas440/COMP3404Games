using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project.Behaviours
{
    public class Behaviour: IBehaviour
    {
        protected Vector2 _velocity;

        public virtual Vector2 Velocity { get; }
        public IEntity _myEntity { set; get; }
        public virtual void OnUpdate(Object sender, UpdateEventArgs UpdateEventArgs) { }
    }
}
