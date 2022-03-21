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
        private Vector2 _target;
        //DECLARE a Bool called _moving
        private bool _isMoving;

        //DECLARE two bools _xReached and _yReached
        private bool _xReached;
        private bool _yReached;

        /// <summary>
        /// The Default Constructor
        /// </summary>
        public CannonBall() 
        {
            //Sets the location to -1 -1
            _entityLocn.X = -1;
            _entityLocn.Y = -1;
            //Sets _isMoving to false
            _isMoving = false;
        }
        /// <summary>
        /// A method used to start the cannonball moving
        /// </summary>
        /// <param name="pTarget">The target of the cannonball</param>
        public void StartMoving(Vector2 pTarget) 
        {
            //Sets the _target to pTarget
            _target = pTarget;
            //sets _isMoving to true
            _isMoving = true;
            //Sets xReached and yReached flags to false
            _xReached = false;
            _yReached = false;
        }
        /// <summary>
        /// A method used to update the object
        /// </summary>
        public override void update()
        {
            //Calls update in the base class
            base.update();
            //If the moving flag is true this is true
            if (_isMoving == true) 
            {
                //If the entites X position is less than the X position it needs to move to
                // And xReached flag is false, This is true
                if (_entityLocn.X <= _target.X && _xReached == false) 
                {
                    //Increments the x position
                    _entityLocn.X++;
                }
                //If the entites X position is more than the X position it needs to move to
                // And xReached flag is false, This is true
                else if (_entityLocn.X > _target.X && _xReached == false) 
                {
                    //Reduces the X position
                    _entityLocn.X--;
                }
                //If the x position is Greater than the target position -10
                //And the x position is less than the target position +10
                //this is true
                if (_entityLocn.X  >= _target.X - 10 && _entityLocn.X <= _target.X + 10) 
                {
                    //Sets the xReached flag to true
                    _xReached = true;
                }
                //If the entites y position is less than the y position its target
                // And yReached flag is false, This is true
                if (_entityLocn.Y <= _target.Y && _yReached == false) 
                {
                    //Increments the Y position
                    _entityLocn.Y++;
                }
                //If the entites y position is more than the y position its target
                // And yReached flag is false, This is true
                else if (_entityLocn.Y > _target.Y && _yReached == false)
                {
                    //Reduces the yPosition
                    _entityLocn.Y--;
                }
                //If the y position is Greater than the target position -10
                //And the y position is less than the target position +10
                //this is true
                if (_entityLocn.Y >= _target.Y - 10 && _entityLocn.Y <= _target.Y + 10)
                {
                    //Sets the yReached flag to true
                    _yReached = true;
                }
                //If both flags are true this is true
                if (_xReached && _yReached) 
                {
                    //Sets the moving flag to false
                    _isMoving = false;
                    //Sets the entity back to 0 0 
                    _entityLocn.Y = 0;
                    _entityLocn.X = 0;
                }
            }
        }
    }
}
