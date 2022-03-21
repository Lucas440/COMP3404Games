using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Authors Lucas Brennan, Flynn Osborne & Will Eardley
/// 
/// Date 14/03/2022
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class that represents the cannonball
    /// </summary>
    public class CannonBall : DrVsVirusEntity
    {
        //DECLARE A Vector2 called _moveToo
        Vector2 _moveToo;
        //DECLARE a Bool called _moving
        bool _moving;

        bool xReached;
        bool yReached;

        /// <summary>
        /// The Default Constructor
        /// </summary>
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
            xReached = false;
            yReached = false;
        }
        /// <summary>
        /// A method used to update the object
        /// </summary>
        public override void update()
        {
            base.update();

            if (_moving == true) 
            {

                if (_entityLocn.X <= _moveToo.X && xReached == false) 
                {
                    _entityLocn.X++;
                }
                else if (_entityLocn.X > _moveToo.X && xReached == false) 
                {
                    _entityLocn.X--;
                }

                if (_entityLocn.X  >= _moveToo.X - 10 && _entityLocn.X <= _moveToo.X + 10) 
                {
                    xReached = true;
                }

                if (_entityLocn.Y <= _moveToo.Y) 
                {
                    _entityLocn.Y++;
                }
                else if (_entityLocn.Y > _moveToo.Y)
                {
                    _entityLocn.Y--;
                }
                else 
                {
                    yReached = true;
                }

                if (_entityLocn.Y >= _moveToo.Y - 10 && _entityLocn.Y <= _moveToo.Y + 10)
                {
                    yReached = true;
                }

                if (xReached && yReached) 
                {
                    _moving = false;
                    _entityLocn.Y = 0;
                    _entityLocn.X = 0;
                }
            }
        }
    }
}
