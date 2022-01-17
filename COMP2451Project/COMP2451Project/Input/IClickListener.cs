using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHOR Lucas Brennan
///
/// </summary>
namespace COMP3451Project.Managers.Input
{
    interface IClickListener
    {
        /// <summary>
        /// A method that responds to a mouseClick
        /// </summary>
        /// <param name="sorce">the source of the event</param>
        /// <param name="args">the event argument</param>
         void OnNewClick(object sorce , ClickEventArgs args);
    }
}
