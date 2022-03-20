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
        Vector2[,] _cannonLanding;


        /// <summary>
        /// A Method which sets the screens boundarys
        /// </summary>
        /// <param name="pHight">The hight of the screen</param>
        /// <param name="pWidth">The Width of the Screen</param>
        public override void setBoundaries(double pWidth, double pHight)
        {
            //Calls the base method
            base.setBoundaries(pWidth, pHight);
            //Initlises _cannonLanding
            _cannonLanding = new Vector2[7,5];

            for (int x = 0; x < 7; x++) 
            {
                for (int y = 0; y < 5; y++) 
                {
                    _cannonLanding[x, y] = new Vector2();
                    _cannonLanding[x, y].X = x * (int)(_screenWidth / 7);
                    _cannonLanding[x, y].Y = y * (int)(_screenWidth / 5);
                }
            }
        }

        // ---------------------------------------- IClick Listener Implenetation ------------------------------------------------

        /// <summary>
        /// A Method that responds to a click
        /// </summary>
        /// <param name="sender">The object that called the event</param>
        /// <param name="args">The event argument</param>
        public void OnNewClick(object sender , ClickEventArgs args) 
        {
            if (args.mouseState.LeftButton == ButtonState.Released)
            {
                foreach (Vector2 top in _cannonLanding)
                {
                    foreach (Vector2 bottom in _cannonLanding)
                    {
                        if(args.mouseState.X > top.X && args.mouseState.X < bottom.X)
                        {
                            if (args.mouseState.Y > top.Y && args.mouseState.Y < bottom.Y) 
                            {

                                double X = (top.X + bottom.X) / 2;
                                double Y = (top.Y + bottom.Y) / 2;

                            }
                        }
                    }
                }
            }
        }
    }
}
