using DrVsVirusGame.GameBehaviours.EnemyBehaviour;
using DrVsVirusGame.GameStates.VirusStates;
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
    /// A Class that Represents the Virus Enemy
    /// </summary>
    public class Virus : Enemy
    {
        //DECLARE a new IState called _currentState
        private IState _currentState;

        //DECLARE a new IState called _movingState
        private IState _movingState;

        //DECLARE a new event called _currentBehaviour
        public event OnUpdateEvent _currentBehaviour;
        /// <summary>
        /// A Delegate for an event which happens when the class is updated
        /// </summary>
        /// <param name="sender">The object that called the event</param>
        /// <param name="args">The event argument / data</param>
        public delegate void OnUpdateEvent(object sender, UpdateEventArgs args);

        /// <summary>
        /// The Default Contsructor
        /// </summary>
        public Virus() 
        {
        }
        /// <summary>
        /// A Method that sets the starting location of the virus
        /// </summary>
        /// <param name="pLocn">The StartingLocation (Not used in this method)</param>
        public override void StartingLocation(Vector2 pLocn)
        {
            //Initalise a new Random called rnd
            Random rnd = new Random();

            //Sets _entityLocn X position to _screenWidth + 50
            _entityLocn.X = (float)(_screenWidth + 50);
            //Sets _entityLocon Y to a random number between 0 and _screenHeight
            _entityLocn.Y = rnd.Next(0 , Convert.ToInt32(_screenHight));

            //INITALISE class Varibles
            //_behaviour
            _behaviour = new VirusBehaviour();
            ((Behaviour)_behaviour)._myEntity = this;
            //_movingState
            _movingState = new VirusState("Moving");
            //Sets MovingState Entity to this
            _movingState._entity = this;
            ((State)_movingState)._behaviour = _behaviour;
            //_currentState
            _currentState = _movingState;

            //Adds _behaviours OnUpdate Method to the event
            _currentBehaviour += _behaviour.OnUpdate;

        }
        /// <summary>
        /// Updates the Virus
        /// </summary>
        public override void update()
        {
            //Updates the current state
            _currentState.Update();
            //sets the location to the behaviours location
            _entityLocn = _behaviour.Location;

            if (_entityLocn.X < 0) 
            {
                Environment.Exit(1);
            }
        }
    }
}
