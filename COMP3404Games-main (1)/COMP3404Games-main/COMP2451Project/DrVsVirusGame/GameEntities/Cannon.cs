using Engine.InputEvents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHORS: Lucas Brennan, Flynn Osborne & Will Eardley
/// DATE: 28/03/2022
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class used for the cannon game entity
    /// </summary>
    public class Cannon : DrVsVirusEntity, IClickListener
    {
        // DECLARE a variable to hold a cannonball
        CannonBall _ball;

        /// <summary>
        /// A method that passes an instance of the cannonball to the cannon
        /// </summary>
        /// <param name="pBall">The cannonball instance</param>
        public void SetCannonBall(CannonBall pBall) 
        {
            // SET the cannonball
            _ball = pBall;
        }

        // ---------------------------------------- IClick Listener Implenetation ------------------------------------------------

        /// <summary>
        /// A Method that responds to a click
        /// </summary>
        /// <param name="sender">The object that called the event</param>
        /// <param name="args">The event argument</param>
        public void OnNewClick(object sender , ClickEventArgs args) 
        {
            // When the mouse is clicked:
            if (args.mouseState.LeftButton == ButtonState.Pressed)
            {
                // Ensure that the player cannot change the course of the projectile mid-flight
                if (_ball.Moving == false)
                {
                    // Fire the projectile
                    _ball.StartMoving(new Vector2(args.mouseState.X, args.mouseState.Y));
                }
            }
        }
    }
}
