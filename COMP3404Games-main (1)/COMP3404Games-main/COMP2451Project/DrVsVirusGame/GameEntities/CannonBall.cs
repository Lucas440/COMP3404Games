using DrVsVirusGame.GameBehaviours.CannonBehaviours;
using DrVsVirusGame.GameStates;
using Engine.Behaviours;
using Engine.EngineStates;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHORS: Lucas Brennan, Flynn Osborne & Will Eardley
/// 
/// DATE: 21/03/2022
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class that represents the cannonball
    /// </summary>
    public class CannonBall : Friendly
    {
        // DECLARE a Bool called _moving
        private bool _isMoving;

        // DECLARE a property to return the ball's state
        public bool Moving { get => _isMoving; }

        // DECLARE A Vector2 called _target
        private Vector2 _target;

        /// <summary>
        /// A Property used to return the cannonball's target
        /// </summary>
        public Vector2 Target { get => _target; }

        // DECLARE an IState called _movingState
        IState _movingState;

        /// <summary>
        /// The Default Constructor
        /// </summary>
        public CannonBall()
        {
            //Sets Damage to 100
            _damage = 100;

            // SETS the location to -1 -1
            _entityLocn.X = -1;
            _entityLocn.Y = -1;

            gridXLocation = 0;
            gridYLocation = 0;

            // SETS _isMoving to false
            _isMoving = false;

            //INITIALISE a new CannonBallState
            _movingState = new CannonBallState();

            //INITIALISE _behaviour
            _behaviour = new CannonBallBehaviour();
            // SETS the behviour's entity to this
            ((Behaviour)_behaviour)._myEntity = this;
            // SETS the state's entity to this
            _movingState._entity = this;
            // SETS the state's Behaviour to _behaviour
            _movingState.Behaviour = _behaviour;

        }

        /// <summary>
        /// A method used to start the cannonball moving
        /// </summary>
        /// <param name="pTarget">The target of the cannonball</param>
        public void StartMoving(Vector2 pTarget)
        {

            // SETS the _target to pTarget
            _target = pTarget;

            //DECLARE Bool xValid and yValid set both to false
            bool xValid = false;
            bool yValid = false;

            // Observes the horizontal grid position
            for (int i = 0; i < _gridX.Length - 1; i++)
            {
                // Check each column to find the target
                if (_target.X >= _gridX[i] && _target.X < _gridX[i + 1])
                {
                    //set xValid to true
                    xValid = true;
                    break;
                }
            }

            // Observes the vertical grid position
            for (int i = 0; i < _gridY.Length - 1; i++)
            {
                // Check each row to find the target
                if (_target.Y >= _gridY[i] && _target.Y < _gridY[i + 1])
                {
                    //Set yValid to true
                    yValid = true;
                    break;
                }
            }
            //If xValid and yValid are true this is true
            if (xValid && yValid) 
            {
                //Set isMoving to true
                _isMoving = true;
                ((CannonBallBehaviour)_behaviour).IsMoving = true;
            } 
        }

        public override void update()
        {
            base.update();

            // IF the ball is currently moving:
            if (_isMoving == true)
            {
                // UPDATES _movingState
                _movingState.Update();
                // SETS _entityLocn to _behaviour's location
                _entityLocn = _behaviour.Location;

                // SETS _isMoving to _behaviour's IsMoving property
                _isMoving = ((CannonBallBehaviour)_behaviour).IsMoving;

            }

            // Output the ball's current grid location
            UpdateGridLocation();
        }

        /// <summary>
        /// A Method that returns the cannonballs hitbox
        /// </summary>
        /// <returns>A Rectangle that represents the hitbox</returns>
        public override Rectangle getHitBox()
        {
            //If the entity isnt moving and
            //If the entitys gridY and gridX location -1 is greater than or Equal to 0 this is true
            if (_isMoving == false && (gridYLocation - 1 >= 0 && gridXLocation - 1 >= 0))
            {
                //Creates a new rectangle which represents the cannon balls hit box when it lands on the ground
                _hitBox = new Rectangle(_gridX[gridXLocation - 1], _gridY[gridYLocation - 1], 100, 100);
                //Sets the location to 0 0 
                _entityLocn.X = 0;
                _entityLocn.Y = 0;
            }
            //Returns the hit box
            return _hitBox;
        }
    }
}
