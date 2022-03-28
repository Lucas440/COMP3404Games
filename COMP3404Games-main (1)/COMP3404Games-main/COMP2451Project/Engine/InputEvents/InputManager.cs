using Microsoft.Xna.Framework.Input;

/// <summary>
/// AUTHOR: Lucas Brennan
/// MODIFIED BY: Flynn Osborne
/// DATE: 14/03/2022
/// </summary>
namespace Engine.InputEvents
{
    /// <summary>
    /// A class used to respond to inputs and publish those events
    /// </summary>
    public class InputManager : IEventPublisher, IInputPublisher, IClickPublisher
    {
        // DECLARE a variable to hold a KeyboardState
        KeyboardState _keyBoardState;

        // DECLARE a variable to hold a MouseState
        MouseState _mouseState;

        /// <summary>
        /// A method that updates the input manager
        /// </summary>
        public void update()
        {
            // IF the held keyboardState is not equal to the keyboard's current state:
            if (_keyBoardState != Keyboard.GetState())
            {
                // UPDATE the held keyboardState
                _keyBoardState = Keyboard.GetState();

                // CALL the OnNewInput method
                OnNewInput();
            }

            // IF the held mouseState is not equal to the mouse's current state:
            if (_mouseState.LeftButton != Mouse.GetState().LeftButton)
            {
                // IF the left mouse button has been pressed:
                if (_mouseState.LeftButton == ButtonState.Pressed)
                {
                    // CALL OnNewClick method
                    OnNewClick();
                }

                // UPDATE the mouseState
                _mouseState = Mouse.GetState();

            }

        }
        /// <summary>
        /// A method that raises the events
        /// </summary>
        protected virtual void OnNewInput()
        {
            // IF NewInput is not null:
            if (NewInput != null)
            {
                // RAISE the events and pass through the arugments
                NewInput(this, new InputEventArgs() { keyboardState = this._keyBoardState });
            }
        }

        /// <summary>
        /// A method that raises the NewClick event
        /// </summary>
        protected virtual void OnNewClick()
        {
            // If NewClick is not null:
            if (NewClick != null)
            {
                // RAISE the event and pass this and the mouseState
                NewClick(this, new ClickEventArgs() { mouseState = this._mouseState });
            }
        }

        /// <summary>
        /// The constructor for the class
        /// </summary>
        public InputManager()
        {
            // INITIALISE the keyboardState to the current state of the keyboard
            _keyBoardState = Keyboard.GetState();

            // INITIALISE the mouseState to the current state of the mouse
            _mouseState = Mouse.GetState();
        }


        //------------------------------------------------------ IInputPublisher Implementation ------------------------------------------

        /// <summary>
        /// A delegate for the Event 
        /// </summary>
        /// <param name="source">What is sending the event</param>
        /// <param name="args">The data of the event</param>
        public delegate void InputEventHandler(object source, InputEventArgs args);

        // RAISE a new Input event
        public event InputEventHandler NewInput;

        /// <summary>
        /// A method to subscribe a listener
        /// </summary>
        /// <param name="listener">The object being subscribed</param>
        public void subscribe(IKeyListener listener)
        {
            // SUBSCRIBE the listener to NewInput
            NewInput += listener.OnNewInput;
        }

        /// <summary>
        /// A method to remove a listener
        /// </summary>
        /// <param name="keyListener">The listener being removed</param>
        public void unSubscribe(IKeyListener keyListener)
        {
            // UNSUBSCRIBE the listener from the event
            NewInput -= keyListener.OnNewInput;
        }

        // ------------------------------------------------- IClickPublisher implementation -----------------------------------------------

        /// <summary>
        /// A delegate for the mouseClick event
        /// </summary>
        /// <param name="source">Where the method is called from</param>
        /// <param name="args">The event data</param>
        public delegate void MouseEventHandler(object source, ClickEventArgs args);

        // RAISE a new mouseClick event
        public event MouseEventHandler NewClick;


        /// <summary>
        /// A method that subscribes a listener
        /// </summary>
        /// <param name="listener">The object being subscribed</param>
        public void subscribe(IClickListener listener)
        {
            // SUBSCRIBE the listener to NewClick
            NewClick += listener.OnNewClick;
        }

        /// <summary>
        /// A method that removes a listener
        /// </summary>
        /// <param name="keyListener">The listener being removed</param>
        public void unSubscribe(IClickListener keyListener)
        {
            // REMOVE the listener from NewInput
            NewClick -= keyListener.OnNewClick;
        }

    }
}
