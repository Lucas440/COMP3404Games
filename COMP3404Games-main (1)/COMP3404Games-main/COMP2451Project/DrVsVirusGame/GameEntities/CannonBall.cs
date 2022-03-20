using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrVsVirusGame.GameEntities
{
    public class CannonBall : DrVsVirusEntity
    {
        Vector2 _moveToo;

        bool _moving;

        public CannonBall() 
        {
            _entityLocn.X = -1;
            _entityLocn.Y = -1;
            _moving = false;
        }

        public void StartMoving(Vector2 pMoveToo) 
        {
            _moveToo = pMoveToo;
            _moving = true;
        }

        public override void update()
        {
            base.update();

            if (_moving == true) 
            {
                if (_entityLocn.X < _moveToo.X) 
                {
                    _entityLocn.X++;
                }
                else if (_entityLocn.X > _moveToo.X) 
                {
                    _entityLocn.X--;
                }

                if (_entityLocn.Y < _moveToo.Y) 
                {
                    _entityLocn.Y++;
                }
                else if (_entityLocn.Y > _moveToo.Y)
                {
                    _entityLocn.Y--;
                }
            }
        }
    }
}
