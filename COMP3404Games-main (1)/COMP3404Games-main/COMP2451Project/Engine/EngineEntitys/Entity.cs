using Engine.Behaviours;
using Engine.Command;
using Engine.EngineStates;
using Microsoft.Xna.Framework;
using System;
/// <summary>
/// AUTHOR: Lucas Brennan & Flynn Osborne
/// DATE: 07/02/2022
/// </summary>
namespace Engine.EngineEntitys
{
    /// <summary>
    /// A Class used to represen entities in the game
    /// </summary>
    public abstract class Entity : IEntity, IEntityInternal, ICommandSender
    {
        // A variable to hold the entity's behaviour
        protected IBehaviour _behaviour;

        // A variable to hold the entity's current state
        protected IState _state;

        // Creates a vector called ballLocn
        protected Vector2 _entityLocn;

        //DECLARE a double called _screenWidth
        protected double _screenWidth;
        //DECLARE a double called _screenHight
        protected double _screenHight;

        /// <summary>
        /// Updates the entity on each loop
        /// </summary>
        public virtual void update() { }

        /// <summary>
        /// Returns the objects Position
        /// </summary>
        public Vector2 Position { get => _entityLocn; }
        /// <summary>
        /// A Property that returns the state as a text
        /// </summary>
        public string StateText { get; set; }

        /// <summary>
        /// Changes the entity's state 
        /// </summary>
        /// <param name="pState">The state the entity must change to</param>
        public virtual void SetState(IState pState)
        {
            _state = pState;
        }

        //----------------------------------------------------------------- ICommandSender Implementation ----------------------------------

        /// <summary>
        /// A Property used to set a ScheduleCommand action
        /// </summary>
        public Action<ICommand> ScheduleCommand { get; set; }

        // ---------------------------------------------------- IEntityInternal Implementation -------------------------------------------

        /// <summary>
        /// A property used to store a Terminate Method
        /// </summary>
        public ICommand TerminateMe { get; set; }

        /// <summary>
        /// A Property used to Store a Remove MEthod
        /// </summary>
        public ICommand RemoveMe { get; set; }

    }
}
