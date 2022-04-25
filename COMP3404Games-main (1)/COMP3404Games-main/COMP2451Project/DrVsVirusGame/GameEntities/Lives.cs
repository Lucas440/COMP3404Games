using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 17/04/2022
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class which represents the amount of lives remaining
    /// </summary>
    public class Lives : DrVsVirusEntity
    {
        // The number of Lives Remaining
        private int _livesRemaining;

        /// <summary>
        /// A Property which returns the anount of lives
        /// </summary>
        public int LivesRemaining { get => _livesRemaining; }

        /// <summary>
        /// The Default Constructor
        /// </summary>
        public Lives() 
        {
            // SET the number of lives
            _livesRemaining = 3;
        }

        /// <summary>
        /// A Method which reduces lives
        /// </summary>
        public void ReduceLives() 
        {
            // DECREASE the life count by 1
            _livesRemaining -= 1;  
        }

        /// <summary>
        /// A Method which reduces lives
        /// </summary>
        public void IncreaseLives()
        {
            // INCREASE the life count by 1
            _livesRemaining += 1;
        }

        /// <summary>
        /// A Method that updates lives
        /// </summary>
        public override void update()
        {
            // SET the statetext
            StateText = "Your Lives: " + LivesRemaining;
        }
    }
}
