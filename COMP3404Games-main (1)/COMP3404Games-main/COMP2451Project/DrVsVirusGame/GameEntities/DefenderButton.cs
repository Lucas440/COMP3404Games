using Engine.Command;
using Engine.InputEvents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 4/4/2022
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class that represents a button which creates a defender
    /// </summary>
    public class DefenderButton : DrVsVirusEntity, IClickListener
    {
        //DECLARE a bool called _buttonSelected
        private bool _buttonSelected;
        /// <summary>
        /// The Default Constructor
        /// </summary>
        public DefenderButton() 
        {
            //Sets _buttonSelected to false
            _buttonSelected = false;
        }

        /// <summary>
        /// A Method that Responds to a button Click
        /// </summary>
        /// <param name="sorce">the object that raised the event</param>
        /// <param name="args">the event argument</param>
        public void OnNewClick(object sorce, ClickEventArgs args)
        {
            //If Left mouse button has been clicked and _buttonSelected is false
            //This is true
            if (args.mouseState.LeftButton == ButtonState.Pressed && _buttonSelected == false) 
            {
                //If the click was within X the bounds of the texture this is true
                if (args.mouseState.X > _entityLocn.X - _texture.Height && args.mouseState.X <= _entityLocn.X + _texture.Height) 
                {
                    //If the click was within Y the bounds of the texture this is true
                    if (args.mouseState.Y > _entityLocn.Y - _texture.Height && args.mouseState.Y <= _entityLocn.Y + _texture.Height) 
                    {
                        //Sets _buttonSelected to true
                        _buttonSelected = true; 
                    }
                }
            }
            //If Left mouse button has been clicked and _buttonSelected is true
            //This is true
            else if (args.mouseState.LeftButton == ButtonState.Pressed && _buttonSelected == true) 
            {
                //Sets the data of create defender to a new Vector2 at the mouse location
                ((ICommandOneParam<Vector2>)CreateDefender).SetData = new Vector2(args.mouseState.X , args.mouseState.Y);
                //Schedules the command
                ScheduleCommand.Invoke(CreateDefender);
                //Sets _buttonSelected to false
                _buttonSelected = false;
            }
        }
        /// <summary>
        /// A Property used to set a ICommand 
        /// </summary>
        public Engine.Command.ICommand CreateDefender { get; set; }
    }
}
