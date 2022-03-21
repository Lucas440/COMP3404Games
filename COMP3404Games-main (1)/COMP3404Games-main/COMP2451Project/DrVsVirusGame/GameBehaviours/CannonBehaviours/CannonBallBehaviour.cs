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
/// Author Lucas Brennan
/// 
/// Date 21/03/22
/// </summary>
namespace DrVsVirusGame.GameBehaviours.CannonBehaviours
{   
    /// <summary>
    /// A Class that represents the Cannon Balls Behaviour 
    /// </summary>
    public class CannonBallBehaviour : DrVsVirusBehaviour
    {
        /// <summary>
        /// A Property to determain if the CannonBall is moving
        /// </summary>
        public bool IsMoving { get; set; }

        //DECLARE two floats called _xSpeed and _ySpeed
        private float _xSpeed;
        private float _ySpeed;

        //DECLARE an int called _time
        private int _time;

        /// <summary>
        /// the default constructor
        /// </summary>
        public CannonBallBehaviour() 
        {
            //Sets _xSpeed and _ySpeed back to 0
            _ySpeed = 0;
            _xSpeed = 0;
            //Sets time to 60 frames of 1 second
            _time = 60;
        }

        /// <summary>
        /// A Method that caluclates the speed of the cannon ball so that it always reaches the
        /// target in a set amount of time
        /// </summary>
        /// <param name="pCannonBall"></param>
        private void CalculateSpeed(CannonBall pCannonBall) 
        {
            //Calculates the speed by using the distance from the target divided by the time
            _xSpeed = pCannonBall.Target.X / _time;
            _ySpeed = pCannonBall.Target.Y / _time;
        }

        /// <summary>
        /// A Method that responds to an update
        /// </summary>
        /// <param name="sender">The object that is being updated</param>
        /// <param name="UpdateEventArgs">The event argument</param>
        public override void OnUpdate(object sender, UpdateEventArgs UpdateEventArgs)
        {
            //DECLARES xReached and yReached flags and sets them to false
            bool _xReached = false;
            bool _yReached = false;
            //If xSpeed and _ySpeed are 0 this is true
            if (_xSpeed == 0 && _ySpeed == 0) 
            {
                //Calls CalculateSpeed
                CalculateSpeed((CannonBall)sender);
            }

            //Sets _location to the sender position
            _location = ((IEntity)sender).position();

            //If the entites X position is less than the X position it needs to move to
            // And xReached flag is false, This is true
            if ( (_location.X  <= ((CannonBall)sender).Target.X && _xReached == false))
            {
                //Increments the x position
                _location.X += _xSpeed;
            }
            //If the entites X position is more than the X position it needs to move to
            // And xReached flag is false, This is true
            else if (_location.X > ((CannonBall)sender).Target.X && _xReached == false)
            {
                //Reduces the X position
                _location.X-= _xSpeed;
            }
            //If the x position is Greater than the target position -10
            //And the x position is less than the target position +10
            //this is true
            if (_location.X >= ((CannonBall)sender).Target.X - 10 && _location.X <= ((CannonBall)sender).Target.X + 10)
            {
                //Sets the xReached flag to true
                _xReached = true;
            }
            //If the entites y position is less than the y position its target
            // And yReached flag is false, This is true
            if (_location.Y <= ((CannonBall)sender).Target.Y && _yReached == false)
            {
                //Increments the Y position
                _location.Y+= _ySpeed;
            }
            //If the entites y position is more than the y position its target
            // And yReached flag is false, This is true
            else if (_location.Y > ((CannonBall)sender).Target.Y && _yReached == false)
            {
                //Reduces the yPosition
                _location.Y-= _ySpeed;
            }
            //If the y position is Greater than the target position -10
            //And the y position is less than the target position +10
            //this is true
            if (_location.Y >= ((CannonBall)sender).Target.Y - 10 && _location.Y <= ((CannonBall)sender).Target.Y + 10)
            {
                //Sets the yReached flag to true
                _yReached = true;
            }
            //If both flags are true this is true
            if (_xReached && _yReached)
            {
                //Sets the entity back to 0 0 
                _location.Y = 0;
                _location.X = 0;

                //Sets _xSpeed and _ySpeed back to 0
                _ySpeed = 0;
                _xSpeed = 0;

                //Sets IsMoving to false
                IsMoving = false;
            }
        }
    }
}
