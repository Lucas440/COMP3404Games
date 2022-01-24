﻿using COMP2451Project.Behaviours;
using COMP3451Project.Managers.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace COMP2451Project
{
    class Paddle : PongEntity, IKeyListener
    {
        //DECLARES an int called speed
        int speed;
        //DECLARES a vector2 called currentDirection
        Vector2 CurrentDirection;

        //DECLARES a PlayerIndex variable that stores which player is controlling this paddle
        PlayerIndex index;

        //DECLARES a OnUpdateEvent called _activeBehaviour
        public event OnUpdateEvent _activeBehaviour;
        /// <summary>
        /// Declares a delegate for the OnUpdateEvent 
        /// </summary>
        /// <param name="source">The object that caused the event to trigger</param>
        /// <param name="args">The event Argument</param>
        public delegate void OnUpdateEvent(object source, UpdateEventArgs args);

        /// <summary>
        /// Is the Constructor for the Paddle
        /// </summary>
        /// <param name="paddleLocation">Passes the paddles Location</param>
        /// <param name="pIndex">Passes which player is controlling this paddle</param>>
        public Paddle(Vector2 paddleLocation, PlayerIndex pIndex)
        {
            //INITALZIES objectType in the parent class
            objectType = "paddle";
            //INITALZIES entitylocn in the parent class
            EntityLocn = paddleLocation;
            // INTIALIZES speed to 5
            speed = 5;
            // Sets the index to player passed
            index = pIndex;
            //INTIALIZES _behaviour
            _behaviour = new PaddleBehaviour();
            //Sets the Entity in _behaviour to this
            ((Behaviour)_behaviour)._myEntity = this;
            //Subscribes the OnUpdate method to the event
            _activeBehaviour += _behaviour.OnUpdate;

        }


        /// <summary>
        /// Returns the entitys texture
        /// </summary>
        /// <returns>Entity - The objects Texture</returns>
        public override Texture2D texture()
        {
            //Returns Entity
            return _Entity;
        }


        /// <summary>
        /// Updates the Paddle on each loop
        /// </summary>-
        public override void update()
        {
            EntityLocn.Y += _behaviour.Velocity.Y * 5;
            // calls the update method in the parent class
            base.update();
            // calls the check wall colision method
            checkWallColision();


        }
        /// <summary>
        /// Checks the colision with the paddle and the wall
        /// </summary>
        public override void checkWallColision()
        {
            // if the y position is less than 0 this is true
            if (EntityLocn.Y < 0)
            {
                // sets the y position to 0
                EntityLocn.Y = 50;
            }
            // else if the y position is greater than the hight minus 150 this is true
            else if (EntityLocn.Y > Height - 150)
            {
                // sets the y postion to the screen height - 150
                EntityLocn.Y = (float)(Height - 150);
            }
        }
        /// <summary>
        /// Returns the current direction of the paddle
        /// </summary>
        /// <returns>CurrentDirection - The Current Velocity and postion of the player</returns>
        public Vector2 getCurrentDirection()
        {
            return CurrentDirection;
        }

        /// <summary>
        /// A method that does something upon colision
        /// </summary>
        public void colision() { }

        // ------------------------------------- Input Event Implentation ---------------------------------

        /// <summary>
        /// A method that handles a input event
        /// </summary>
        /// <param name="source">The object that raised the event</param>
        /// <param name="e">The event data</param>
        public void OnNewInput(object source, InputEventArgs e)
        {
            // If this is player one this is true
            if (PlayerIndex.One == index)
            {
                //If the W Key is Pressed this is true
                if (e.keyboardState.IsKeyDown(Keys.W))
                {
                    //Calls the active behaviour event and passes this and a new UpdateEvent with the Up string
                    _activeBehaviour(this, new UpdateEventArgs() { ActiveBehaviour = "up" });
                }
                //If the S Key is Pressed this is true
                else if (e.keyboardState.IsKeyDown(Keys.S))
                {
                    //Calls the active behaviour event and passes this and a new UpdateEvent with the down string
                    _activeBehaviour(this, new UpdateEventArgs() { ActiveBehaviour = "down" });
                }
                else
                {
                    //Calls the active behaviour event and passes this and a new UpdateEvent with the stopped string
                    _activeBehaviour(this, new UpdateEventArgs() { ActiveBehaviour = "stopped" });
                }
            }
            // If the current paddle is Player is Player 2
            else if (PlayerIndex.Two == index)
            {
                //If the currebt key down is up this is true
                if (e.keyboardState.IsKeyDown(Keys.Up))
                {
                    //Calls the active behaviour event and passes this and a new UpdateEvent with the Up string
                    _activeBehaviour(this, new UpdateEventArgs() { ActiveBehaviour = "up" });
                }
                //If the currebt key down is down this is true
                else if (e.keyboardState.IsKeyDown(Keys.Down))
                {
                    //Calls the active behaviour event and passes this and a new UpdateEvent with the down string
                    _activeBehaviour(this, new UpdateEventArgs() { ActiveBehaviour = "down" });
                }
                else
                {
                    //Calls the active behaviour event and passes this and a new UpdateEvent with the stopped string
                    _activeBehaviour(this, new UpdateEventArgs() { ActiveBehaviour = "stopped" });
                }
            }
        }
    }
}