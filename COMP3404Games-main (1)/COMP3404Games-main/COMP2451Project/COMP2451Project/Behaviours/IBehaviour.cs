using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project.Behaviours
{
    public interface IBehaviour
    {
        Vector2 Velocity { get; }
        void OnUpdate(Object sender, UpdateEventArgs UpdateEventArgs);
    }
}
