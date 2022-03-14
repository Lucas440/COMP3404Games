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
        }
        /// <summary>
        /// Updates the Virus
        /// </summary>
        public override void update()
        {
            _entityLocn.X--;
        }
    }
}
