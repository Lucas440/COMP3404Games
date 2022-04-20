using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 17/04/22
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class which represents the amount of lives remaining
    /// </summary>
    public class Lives : DrVsVirusEntity
    {
        //The Amount Of Lives Remaining
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
            _livesRemaining = 3;
        }
        /// <summary>
        /// A Method which reduces lives
        /// </summary>
        public void ReduceLives() 
        {
            _livesRemaining -= 1;  
        }
        /// <summary>
        /// A Method which reduces lives
        /// </summary>
        public void IncreaseLives()
        {
            _livesRemaining += 1;
        }
        /// <summary>
        /// A Method that updates lives
        /// </summary>
        public override void update()
        {
            //Sets the statetext
            StateText = "Your Lives: " + LivesRemaining;
        }
    }
}
