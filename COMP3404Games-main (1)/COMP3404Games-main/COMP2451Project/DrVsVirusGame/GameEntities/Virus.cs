using DrVsVirusGame.GameBehaviours.EnemyBehaviour;
using DrVsVirusGame.GameStates.VirusStates;
using Engine.Behaviours;
using Engine.EngineEntitys;
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
    /// A Class that Represents the Virus Enemy
    /// </summary>
    public class Virus : Enemy
    {
        // DECLARE a new IState called _currentState
        private IState _currentState;

        // DECLARE a new IState called _movingState
        private IState _movingState;

        // DECLARE a new event called _currentBehaviour
        public event OnUpdateEvent _currentBehaviour;

        /// <summary>
        /// A Delegate for an event which happens when the class is updated
        /// </summary>
        /// <param name="sender">The object that called the event</param>
        /// <param name="args">The event argument / data</param>
        public delegate void OnUpdateEvent(object sender, UpdateEventArgs args);

        /// <summary>
        /// The Default Constructor
        /// </summary>
        public Virus() 
        {
            //Set the Hp to 100
            _HP = 100;

            //Sets _damage to 50
            _damage = 50;

           
        }

        /// <summary>
        /// A Method that sets the starting location of the virus
        /// </summary>
        /// <param name="pLocn">The StartingLocation (Not used in this method)</param>
        public override void StartingLocation(Vector2 pLocn)
        {
            // INITIALISE a new Random called rnd
            Random rnd = new Random();

            _entityLocn = pLocn;

            // INITIALISE class variables:
            //_behaviour
            _behaviour = new VirusBehaviour();
            ((Behaviour)_behaviour)._myEntity = this;
            //_movingState
            _movingState = new VirusState("Moving");
            // SETS _movingState's entity to this
            _movingState._entity = this;
            ((State)_movingState).Behaviour = _behaviour;
            //_currentState
            _currentState = _movingState;

            // ADDS _behaviour's OnUpdate Method to the event
            _currentBehaviour += _behaviour.OnUpdate;

        }

        /// <summary>
        /// Updates the Virus
        /// </summary>
        public override void update()
        {
            // UPDATES the current state
            _currentState.Update();
            //sets the location to the behaviours location
            _entityLocn = _behaviour.Location;

            // IF the virus has gone beyond the left side of the screen
            if (_entityLocn.X < 0) 
            {
                //Scedule a command that reduces lives
                ScheduleCommand.Invoke(ReduceLives);
                //Scedule commands to Remove and Terminate this
                ScheduleCommand.Invoke(RemoveMe);
                ScheduleCommand.Invoke(TerminateMe);
                
            }

            // OUTPUT the current grid location
            UpdateGridLocation();


            _entityLocn.Y = _gridY[gridYLocation - 1] + 25;
        }

        /// <summary>
        /// A Method that responds to collisions
        /// </summary>
        /// <param name="pCollidedEntity">The entity the object collided with</param>
        public override void colision(ICollidable pCollidedEntity)
        {
            //If the Collided entity is a Cannonball this is true
            if (pCollidedEntity is CannonBall || pCollidedEntity is DefenderProjectile)
            {
                //REDUCES the Hp by the amount of damage the entity does
                _HP -= ((DrVsVirusEntity)pCollidedEntity).Damge;
                //If _HP is less than 0
                if (_HP <= 0) 
                {
                    //Alter the points the player has
                    ScheduleCommand.Invoke(AlterPoints);
                    //Scedule commands to Remove and Terminate this
                    ScheduleCommand.Invoke(RemoveMe);
                    ScheduleCommand.Invoke(TerminateMe); 
                }
            }
        }
    }
}
