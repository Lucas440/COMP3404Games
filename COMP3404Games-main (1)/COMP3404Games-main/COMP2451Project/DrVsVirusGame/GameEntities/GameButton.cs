using Engine.Command;
using Engine.InputEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 18/04/22
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A class which represents a MainMenuButton
    /// </summary>
    public class GameButton : DrVsVirusEntity, IClickListener
    {
        /// <summary>
        /// A Method that responds to button Clicks
        /// </summary>
        /// <param name="sorce">The object that raised the event</param>
        /// <param name="args">the event arguemnt</param>
        public void OnNewClick(object sorce, ClickEventArgs args)
        {
            //If the mouse is inside the button this is true
            if ((args.mouseState.X > _entityLocn.X - _texture.Width && args.mouseState.X <= _entityLocn.X + _texture.Width) 
                && (args.mouseState.Y > _entityLocn.Y - _texture.Height && args.mouseState.Y <= _entityLocn.Y + _texture.Height)) 
            {
                //Schedules the button clicked command
                ScheduleCommand.Invoke(ButtonClicked);
            }
        }
        /// <summary>
        /// A Property that sets the button clicked command
        /// </summary>
        public ICommand ButtonClicked { get; set; }
    }
}
