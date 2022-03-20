using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrVsVirusGame.GameEntities
{
    public class CannonBall : DrVsVirusEntity
    {
        public CannonBall() 
        {
            _entityLocn.X = -1;
            _entityLocn.Y = -1;
        }

        public void StartMoving() { }
    }
}
