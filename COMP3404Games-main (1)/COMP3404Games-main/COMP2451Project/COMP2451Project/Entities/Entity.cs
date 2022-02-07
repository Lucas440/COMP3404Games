using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP2451Project.Behaviours;
using COMP2451Project.States;
using COMP2451Project.Command;
using COMP2451Project.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace COMP2451Project
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
        protected Vector2 EntityLocn;

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
            return EntityLocn;
        }

        /// <summary>
        /// Changes the entity's state 
        /// </summary>
        /// <param name="pState">The state the entity must change to</param>
        public virtual void SetState(IState pState)
        {

        }

        //----------------------------------------------------------------- ICommandSender Implementation ----------------------------------

        
        public Action<ICommand> ScheduleCommand { get; set; }

        // ---------------------------------------------------- IEntityInternal Implementation -------------------------------------------

        
        public ICommand TerminateMe { get; set; }
        
        //
        public ICommand RemoveMe { get; set; }

    }
}
