using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author: Lucas Brennan
/// Date 6/4/22
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class that represents the points of the user
    /// </summary>
    public class Points : DrVsVirusEntity
    {
        //DECLARE a int called _currentPoints and _totalPoints
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
            // adds the point change to the currentpoints
            _currentPoints += pPointChange;
            //If the point change is greater than 0 this is true
            if (pPointChange > 0 ) 
            {
                //Adds the point change to total points
                _totalPoints += pPointChange;
            }
        }
        /// <summary>
        /// A Method that updates the class
        /// </summary>
        public override void update()
        {
            base.update();
            //Adds 1 to the points
            AlterPoints(1);
        }
    }
}
