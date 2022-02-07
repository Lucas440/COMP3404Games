using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project.States
{
    // AUTHOR: Flynn Osborne
    // DATE: 31/01/2022

    public interface IState
    {
        /// <summary>
        /// The method used to update the entity's state
        /// </summary>
        void Update();

        /// <summary>
        /// The method triggered when the entity collides
        /// </summary>
        void Collide();
    }
}
