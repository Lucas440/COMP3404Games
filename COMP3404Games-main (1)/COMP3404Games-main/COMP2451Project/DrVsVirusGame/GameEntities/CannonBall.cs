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

        /// <summary>
        /// A Property used to return the cannonballs target
        /// </summary>
        public Vector2 Target { get => _target; }

        //DECLARE an IState called _movingState
        IState _movingState;


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

            //INTIALISE a new CannonBallState
            _movingState = new CannonBallState();

            //INTIALISE _behaviour
            _behaviour = new CannonBallBehaviour();
            //Sets the behviours entity to this
            ((Behaviour)_behaviour)._myEntity = this;
            //Sets the states entity to this
            _movingState._entity = this;
            //sets the states Behaviour to _behaviour
            _movingState.Behaviour = _behaviour;

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
            ((CannonBallBehaviour)_behaviour).IsMoving = true;
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
                //Updates _movingState
                _movingState.Update();
                //Sets _entityLocn to _behaviours location
                _entityLocn = _behaviour.Location;

                //sets _isMoving to _behaviours moving property
                _isMoving = ((CannonBallBehaviour)_behaviour).IsMoving;
            }
        }
    }
}
