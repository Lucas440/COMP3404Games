﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP3451Project.Managers.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace COMP2451Project
{
    class InputManager : IEventPublisher , IInputPublisher , IClickPublisher
    {
        // A KeyboardState called keyboardstate
        KeyboardState keyboardState;
        //A MouseState called mouseState
        MouseState mouseState;

        /// <summary>
        /// Updates the input Manager
        /// </summary>
        public void update()
        {
            // if the state of the keyboard is not equal to the current state this is true
            if (keyboardState != Keyboard.GetState())
            {
                //Updates the state of the keyboard
                keyboardState = Keyboard.GetState();
                // Calls the OnNewInput method
                OnNewInput();
            }
            // If mouse state is not the same as current mousestate this is true
            if (mouseState != Mouse.GetState()) 
            {
                //Updates mouseState
                mouseState = Mouse.GetState();
                //Calls onNewCLick method
                OnNewClick();
            }

        }
        /// <summary>
        /// A method that raises the events
        /// </summary>
        protected virtual void OnNewInput()
        {
            // If NewInput is not null this is true
            if (NewInput != null)
            {
                //  Raises the events and passes through the arugments
                NewInput(this, new InputEventArgs(){keyboardState = this.keyboardState});
            }
        }
        /// <summary>
        /// A method that raises the NewClick event
        /// </summary>
        protected virtual void OnNewClick() 
        {
            // If NewCLick is not null this is true
            if (NewClick != null) 
            {
                //Raises the event and passes this and the mousestate
                NewClick(this, new ClickEventArgs() {mouseState = this.mouseState });
            }
        }

            /// <summary>
            /// The constructor for the class
            /// </summary>
            public InputManager() 
        {
            // INTALIZES the keyboardstate to the current state of the keyboard
            keyboardState = Keyboard.GetState();
            //INTALISES mouse state with the current state of the mouse
            mouseState = Mouse.GetState();
        }


        //------------------------------------------------------ IInputPublisher Implementation ------------------------------------------

        /// <summary>
        /// A delegate For the Event 
        /// </summary>
        /// <param name="source">What is sending the event</param>
        /// <param name="args">The data of the event</param>
        public delegate void InputEventHandler(object source, InputEventArgs args);

        // NewInput is raised each time A new input happens
        public event InputEventHandler NewInput;

        /// <summary>
        /// Subscribes a listener
        /// </summary>
        /// <param name="listener">The object being subscribed</param>
        public void subscribe(IKeyListener listener) 
        {
            //Subscribes the listener to NewInput
            NewInput += listener.OnNewInput;
        }

        /// <summary>
        /// Removes a listener
        /// </summary>
        /// <param name="keyListener">listener being removed</param>
        public void unSubscribe(IKeyListener keyListener) 
        {
            //Unsubscribes the listener from the event
            NewInput -= keyListener.OnNewInput;
        }

        // ------------------------------------------------- IClickPublisher implemntation -----------------------------------------------

        /// <summary>
        /// A delagate for the mouseclick event
        /// </summary>
        /// <param name="source">where the method is called from</param>
        /// <param name="args">the event data</param>
        public delegate void MouseEventHandler(object source, ClickEventArgs args);
        //NewClick is raised when ever there is a new mouse clic
        public event MouseEventHandler NewClick;


        /// <summary>
        /// Subscribes a listener
        /// </summary>
        /// <param name="listener">The object being subscribed</param>
        public void subscribe(IClickListener listener)
        {
            //Subscribes the listener to NewClick
            NewClick += listener.OnNewClick;
        }

        /// <summary>
        /// Removes a listener
        /// </summary>
        /// <param name="keyListener">listener being removed</param>
        public void unSubscribe(IClickListener keyListener)
        {
            //UnSubscribes the listener to NewInput
            NewClick -= keyListener.OnNewClick;
        }

    }
}
