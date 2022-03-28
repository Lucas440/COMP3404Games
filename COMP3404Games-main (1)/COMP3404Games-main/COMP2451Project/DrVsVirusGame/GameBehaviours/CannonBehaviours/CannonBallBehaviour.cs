using DrVsVirusGame.GameEntities;
using Engine.Behaviours;
using Engine.EngineEntitys;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHOR: Lucas Brennan
/// 
/// DATE: 21/03/22
/// </summary>
namespace DrVsVirusGame.GameBehaviours.CannonBehaviours
{   
    /// <summary>
    /// A Class that represents the Cannonball's Behaviour 
    /// </summary>
    public class CannonBallBehaviour : DrVsVirusBehaviour
    {
        /// <summary>
        /// A Property to determine if the CannonBall is moving
        /// </summary>
        public bool IsMoving { get; set; }

        // DECLARE two floats called _xSpeed and _ySpeed
        private float _xSpeed;
        private float _ySpeed;

        // DECLARE an int called _time
        private int _time;

        /// <summary>
        /// The default constructor
        /// </summary>
        public CannonBallBehaviour() 
        {
            // SETS _xSpeed and _ySpeed back to 0
            _ySpeed = 0;
            _xSpeed = 0;

            // SETS the time to 60 frames per second
            _time = 180;
        }

        /// <summary>
        /// A Method that caluclates the speed of the cannon ball so that it always reaches the
        /// target in a set amount of time
        /// </summary>
        /// <param name="pCannonBall"></param>
        private void CalculateSpeed(CannonBall pCannonBall) 
        {
            // CALCULATE the speed by using the distance from the target divided by the time
            _xSpeed = (pCannonBall.Target.X - _location.X) / _time;
            _ySpeed = (pCannonBall.Target.Y - _location.Y) / _time;
        }

        /// <summary>
        /// A method that responds to an update
        /// </summary>
        /// <param name="sender">The object that is being updated</param>
        /// <param name="UpdateEventArgs">The event argument</param>
        public override void OnUpdate(object sender, UpdateEventArgs UpdateEventArgs)
        {
            // DECLARES xReached and yReached flags and sets them to false
            bool _xReached = false;
            bool _yReached = false;

            // SETS _location to the sender position
            _location = ((IEntity)sender).Position;

            // IF xSpeed and _ySpeed are 0:
            if (_xSpeed == 0 && _ySpeed == 0) 
            {
                // CALL CalculateSpeed
                CalculateSpeed((CannonBall)sender);
            }


            // IF the entity's X position is less than the X position it needs to move to
            // and xReached flag is false:
            if ( (_location.X  <= ((CannonBall)sender).Target.X && _xReached == false))
            {
                // INCREMENTS the x position
                _location.X += _xSpeed;
            }

            // IF the entity's X position is more than the X position it needs to move to
            // and xReached flag is false:
            else if (_location.X > ((CannonBall)sender).Target.X && _xReached == false)
            {
                // REDUCE the X position
                _location.X-= _xSpeed;
            }

            // IF the X position is Greater than the target position -10
            // and the X position is less than the target position +10:
            if (_location.X >= ((CannonBall)sender).Target.X - 10 && _location.X <= ((CannonBall)sender).Target.X + 10)
            {
                // SET the xReached flag to true
                _xReached = true;
            }
            // IF the entity's Y position is less than the Y position its target
            // and yReached flag is false:
            if (_location.Y <= ((CannonBall)sender).Target.Y && _yReached == false)
            {
                // INCREASE the Y position
                _location.Y+= _ySpeed;
            }
            // IF the entity's Y position is more than the Y position its target
            // and yReached flag is false:
            else if (_location.Y > ((CannonBall)sender).Target.Y && _yReached == false)
            {
                // REDUCE the yPosition
                _location.Y-= _ySpeed;
            }
            // IF the y position is Greater than the target position -10
            // and the y position is less than the target position +10:
            if (_location.Y >= ((CannonBall)sender).Target.Y - 10 && _location.Y <= ((CannonBall)sender).Target.Y + 10)
            {
                // SETS the yReached flag to true
                _yReached = true;
            }
            // IF both flags are true:
            if (_xReached && _yReached)
            {
                // SETS the entity back to 0,0 
                _location.Y = 0;
                _location.X = 0;

                // SET _xSpeed and _ySpeed back to 0
                _ySpeed = 0;
                _xSpeed = 0;

                // SET IsMoving to false
                IsMoving = false;
            }
        }
    }
}
