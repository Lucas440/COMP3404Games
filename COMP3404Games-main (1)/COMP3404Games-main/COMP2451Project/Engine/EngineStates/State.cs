using Engine.Behaviours;
using Engine.Command;
using Engine.EngineEntitys;
using System.Collections.Generic;

namespace Engine.EngineStates
{
    // AUTHOR: Flynn Osborne
    // DATE: 07/02/2022

    public abstract class State : IState
    {
        // A dictionary to hold any commands
        protected IDictionary<string, ICommand> _trigger;

        // A property to set an return a state's linked entity
        public IEntity _entity { set; get; }

        // A property to hold the entity's linked behavior
        public IBehaviour Behaviour { get; set; }

        /// <summary>
        /// The method used to update the entity's state
        /// </summary>
        public virtual void Update()
        {

        }

        /// <summary>
        /// The method triggered when the entity has a collision
        /// </summary>
        public virtual void Collide()
        {

        }
    }
}
