using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using COMP3451.Command;
using COMP3451.Behaviours;
using COMP3451.States;

namespace COMP3451.Entities
{
    // AUTHOR: Lucas Brennan & Flynn Osborne
    // DATE: 07/02/2022

    public abstract class Entity : IEntity , IEntityInternal, ICommandSender 
    {
        // A variable to hold the entity's behaviour
        protected IBehaviour _behaviour;
        
        // A variable to hold the entity's current state
        protected IState _state;

        // Creates a vector called ballLocn
        protected Vector2 _entityLocn;

        /// <summary>
        /// Updates the entity on each loop
        /// </summary>
        public virtual void update() { }

        /// <summary>
        /// Returns the objects Position
        /// </summary>
        /// <returns>The entity current position</returns>
        public virtual Vector2 position()
        {
            // Returns the entity's location
            return _entityLocn;
        }

        /// <summary>
        /// Changes the entity's state 
        /// </summary>
        /// <param name="pState">The state the entity must change to</param>
        public virtual void SetState(IState pState)
        {

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
