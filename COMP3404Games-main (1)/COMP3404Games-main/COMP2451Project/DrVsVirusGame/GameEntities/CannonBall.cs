using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHORS: Lucas Brennan, Flynn Osborne & Will Eardley
/// 
/// DATE: 21/03/2022
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class that represents the cannonball
    /// </summary>
    public class CannonBall : DrVsVirusEntity
    {
        //DECLARE A Vector2 called _moveToo
        Vector2 _moveToo;
        //DECLARE a Bool called _moving
        bool _moving;

        bool xReached = false;
        bool yReached = false;

        /// <summary>
        /// The Default Constructor
        /// </summary>
        public CannonBall() 
        {
            _entityLocn.X = -1;
            _entityLocn.Y = -1;
            _moving = false;
        }

        public void StartMoving(Vector2 pMoveToo) 
        {
            _moveToo = pMoveToo;
            _moving = true;
            xReached = false;
            yReached = false;
        }

        /// <summary>
        /// A method which keeps track of the entity's location within the grid
        /// </summary>
        public void UpdateGridLocation()
        {
            // Observes the horizontal grid position
            for (int i = 0; i < _gridX.Length - 1; i++)
            {
                // Check each column to find the entity
                if (_entityLocn.X >= _gridX[i] && _entityLocn.X < _gridX[i + 1])
                {
                    // Set the horizontal grid location and break the loop
                    gridXLocation = i + 1;
                    break;
                }
                else
                {
                    // Confirm that the entity is in the last column
                    gridXLocation = _gridX.Length;
                }
            }

            // Observes the vertical grid position
            for (int i = 0; i < _gridY.Length - 1; i++)
            {
                // Check each row to find the entity
                if (_entityLocn.Y >= _gridY[i] && _entityLocn.Y < _gridY[i + 1])
                {
                    // Set the vertical grid location and break the loop
                    gridYLocation = i + 1;
                    break;
                }
                else
                {
                    // Confirm that the entity is in the last row
                    gridYLocation = _gridY.Length;
                }
            }

            // Updates the entity's StateText to output the current grid position
            StateText = "Current Grid X: " + gridXLocation + " Current Grid Y: " + gridYLocation;
        }

        public override void update()
        {
            base.update();

            if (_moving == true) 
            {

                if (_entityLocn.X <= _moveToo.X && xReached == false) 
                {
                    _entityLocn.X++;
                }
                else if (_entityLocn.X > _moveToo.X && xReached == false) 
                {
                    _entityLocn.X--;
                }

                if (_entityLocn.X  <= _moveToo.X - 10 && _entityLocn.X >= _moveToo.X + 10) 
                {
                    xReached = true;
                }

                if (_entityLocn.Y <= _moveToo.Y) 
                {
                    _entityLocn.Y++;
                }
                else if (_entityLocn.Y > _moveToo.Y)
                {
                    _entityLocn.Y--;
                }
                else 
                {
                    yReached = true;
                }

                if (_entityLocn.Y <= _moveToo.Y - 10 && _entityLocn.Y >= _moveToo.Y + 10)
                {
                    yReached = true;
                }

                if (xReached && yReached) 
                {
                    _moving = false;
                }
            }

            UpdateGridLocation();
        }
    }
}
