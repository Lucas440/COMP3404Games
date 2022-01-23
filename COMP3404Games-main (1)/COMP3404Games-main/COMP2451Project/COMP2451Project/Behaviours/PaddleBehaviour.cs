using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project.Behaviours
{
    class PaddleBehaviour : PongBehaviour, IUpdateListener
    {

        public override Vector2 Velocity { get => _velocity; }

        public PaddleBehaviour() 
        {

            _velocity = new Vector2();
        }

        public override void OnUpdate(Object sender , UpdateEventArgs UpdateEventArgs) 
        {
            if (UpdateEventArgs.ActiveBehaviour.ToLower() == "up") 
            {
                _velocity.Y = -1;
            }
            else if (UpdateEventArgs.ActiveBehaviour.ToLower() == "down") 
            {
                _velocity.Y = 1;
            }
            else if(UpdateEventArgs.ActiveBehaviour.ToLower() == "stopped") 
            {
                _velocity.Y = 0;
            }
        }
    }
}
