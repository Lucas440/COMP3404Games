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
    public class CannonBall : DrVsVirusEntity
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
            // SETS the location to -1 -1
            _entityLocn.X = -1;
            _entityLocn.Y = -1;

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
            // SETS _isMoving to true
            _isMoving = true;
            ((CannonBallBehaviour)_behaviour).IsMoving = true;
        }

        /// <summary>
        /// A method which keeps track of the entity's location within the grid
        /// </summary>
        public void UpdateGridLocation()
        {
            // Observes the horizontal grid position
            for (int i = 0; i < _gridX.Length - 1; i++)
            {
                // Check each column to find the entity
                if (_entityLocn.X >= _gridX[i] && _entityLocn.X < _gridX[i + 1])
                {
                    // Set the horizontal grid location and break the loop
                    gridXLocation = i + 1;
                    break;
                }
                else
                {
                    // Confirm that the entity is in the last column
                    gridXLocation = _gridX.Length;
                }
            }

            // Observes the vertical grid position
            for (int i = 0; i < _gridY.Length - 1; i++)
            {
                // Check each row to find the entity
                if (_entityLocn.Y >= _gridY[i] && _entityLocn.Y < _gridY[i + 1])
                {
                    // Set the vertical grid location and break the loop
                    gridYLocation = i + 1;
                    break;
                }
                else
                {
                    // Confirm that the entity is in the last row
                    gridYLocation = _gridY.Length;
                }
            }

            // Updates the entity's StateText to output the current grid position
            StateText = "Current Grid X: " + gridXLocation + " Current Grid Y: " + gridYLocation;
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
    }
}
