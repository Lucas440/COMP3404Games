﻿using COMP2451Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHOR Lucas Brennan
///
/// Date 14/02/22
/// </summary>
namespace COMP3451.InputEvents
{
    /// <summary>
    /// An interface used to repersent a object that listens for clicks
    /// </summary>
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
