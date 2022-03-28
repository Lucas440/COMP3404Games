using Engine.InputEvents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
    /// A Class used for the cannon game entity
    /// </summary>
    public class Cannon : DrVsVirusEntity, IClickListener
    {
        CannonBall _ball;

        public void SetCannonBall(CannonBall pBall) 
        {
            _ball = pBall;

            _entityLocn.X = 500;
            _entityLocn.Y = 500;
        }

        // ---------------------------------------- IClick Listener Implenetation ------------------------------------------------

        /// <summary>
        /// A Method that responds to a click
        /// </summary>
        /// <param name="sender">The object that called the event</param>
        /// <param name="args">The event argument</param>
        public void OnNewClick(object sender , ClickEventArgs args) 
        {
            if (args.mouseState.LeftButton == ButtonState.Pressed)
            {
                _ball.StartMoving(new Vector2(args.mouseState.X , args.mouseState.Y));
            }
        }
    }
}
