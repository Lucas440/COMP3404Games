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
        private int _currentPoints;
        private int _totalPoints;

        public int CurrentPoints{ get => _currentPoints;}
        public int TotalPoints { get => _totalPoints; }

        public void AlterPoints(int pPointChange) 
        {
            _currentPoints += pPointChange;
            if (pPointChange > 0 ) 
            {
                _totalPoints += pPointChange;
            }
        }

        public override void update()
        {
            base.update();

            AlterPoints(1);
        }
    }
}
