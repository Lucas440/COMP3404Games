using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP2451Project.Command;
using COMP2451Project.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace COMP2451Project
{
    public abstract class Entity : IEntity , IEntityInternal, ICommandSender 
    {

        //Creates a vector called ballLocn
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
            return EntityLocn;
        }
        //----------------------------------------------------------------- ICommandSender Implementation ----------------------------------

        public Action<ICommand> ScheduleCommand { get; set; }

        // ---------------------------------------------------- IEntityInternal Implementation -------------------------------------------

        public ICommand TerminateMe { get; set; }
        
        public ICommand RemoveMe { get; set; }

    }
}
