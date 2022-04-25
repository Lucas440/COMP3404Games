using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 6/4/2022
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class that represents the points of the user
    /// </summary>
    public class Points : DrVsVirusEntity
    {
        // DECLARE a int called _currentPoints and _totalPoints
        private int _currentPoints;
        private int _totalPoints;

        /// <summary>
        /// A Property used to get the Current points
        /// </summary>
        public int CurrentPoints{ get => _currentPoints;}

        /// <summary>
        /// A Property used to get the total points
        /// </summary>
        public int TotalPoints { get => _totalPoints; }

        /// <summary>
        /// A Method used to Alter the Points
        /// </summary>
        /// <param name="pPointChange">The amount of points to add</param>
        public void AlterPoints(int pPointChange) 
        {
            // ADD the point change to the currentpoints
            _currentPoints += pPointChange;

            // IF the point change is greater than 0:
            if (pPointChange > 0 ) 
            {
                // ADD the point change to total points
                _totalPoints += pPointChange;
            }

            // UPDATE the point count on the screen
            StateText = "Your Points: " + CurrentPoints;
        }

        /// <summary>
        /// A Method that updates the class
        /// </summary>
        public override void update()
        {
            base.update();

            // ADD 1 to the points
            AlterPoints(1);
        }
    }
}
