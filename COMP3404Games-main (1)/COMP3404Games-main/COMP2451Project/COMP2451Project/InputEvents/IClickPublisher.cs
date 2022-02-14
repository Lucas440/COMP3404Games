﻿using System;
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
    /// An interface used to reprsent an object that publishes Clicks
    /// </summary>
    interface IClickPublisher
    {
        /// <summary>
        /// Subscribes a listener
        /// </summary>
        /// <param name="listener">The object being subscribed</param>
        void subscribe(IClickListener listener);

        /// <summary>
        /// Removes a listener
        /// </summary>
        /// <param name="keyListener">listener being removed</param>
        void unSubscribe(IClickListener keyListener);
    }
}
