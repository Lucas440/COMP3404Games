using Engine.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHORS: Lucas Brennan, Flynn Osborne & Will Eardley
/// DATE: 14/03/2022
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// An abstract class that represents the game's enemies
    /// </summary>
    public abstract class Enemy : DrVsVirusEntity
    {
        /// <summary>
        /// A property used to Store a Remove Method
        /// </summary>
        public ICommand AlterPoints { get; set; }
        /// <summary>
        /// A Property to reduceLives
        /// </summary>
        public ICommand ReduceLives { get; set; }
    }
}
