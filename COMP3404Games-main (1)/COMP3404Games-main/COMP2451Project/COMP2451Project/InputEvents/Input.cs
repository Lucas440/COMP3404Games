using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace COMP2451Project
{
    class Input
    {
        // DECLARES a Vector2 variable called direction
        static Vector2 Direction;

        /// <summary>
        /// Gets the current keyboard inputs
        /// Returns the veloicty of the paddle
        /// </summary>
        /// <param name="index">The Current player</param>
        /// <param name="playerVelocity">The loaction and current veloicty of the player</param>
        /// <returns>Direction - The current players velocity</returns>
        public static Vector2 GetKeyBoardInputDirection(PlayerIndex index , Vector2 playerVelocity) 
        {
            // Sets the X direction to the players x velocity
            Direction.X = playerVelocity.X;
            // sets the Y direction to the players y velocity
            Direction.Y = playerVelocity.Y;

            //DECLARES a keyboardstate variable called keyboardstate and INITLIZES it to the current state of the keyboard
            KeyboardState keyboardstate = Keyboard.GetState();

            // if the current player is 1 then this is true
            if (PlayerIndex.One == index)
            {
                // is the current key down is W then this is true
                if (keyboardstate.IsKeyDown(Keys.W))
                {
                    // if the Y direction is less than 0 and greater than -10 then this is true
                    if (Direction.Y < 0 && Direction.Y > -10) 
                    {
                        // the Y direction is Deincrmented by 1
                        Direction.Y -= 1F;
                    }
                    else 
                    {
                        // Sets the Y direction to -1
                        Direction.Y = -1;
                    }
                }
                // else if the Current key pressed is S than this is true
                else if (keyboardstate.IsKeyDown(Keys.S))
                {
                    // if the current Y velocity is greater than 0 and less than 10 then this is trye
                    if (Direction.Y > 0 && Direction.Y < 10)
                    {
                        // Increments Y direction by 1
                        Direction.Y += 1F;
                    }
                    else
                    {
                        // Sets the Y Direction to 1
                        Direction.Y = 1;
                    }
                }
                else
                {
                    // Sets Y direction to 0
                    Direction.Y = 0;
                }
            }
            // Else if the current player is player 2 this is true
            else if (PlayerIndex.Two == index) 
            {
                // is the current key down is the UP arrow then this is true
                if (keyboardstate.IsKeyDown(Keys.Up))
                {
                    // if the Y direction is less than 0 and greater than -10 then this is true
                    if (Direction.Y < 0 && Direction.Y > -10)
                    {
                        // the Y direction is Deincrmented by 1
                        Direction.Y -= 1F;
                    }
                    else
                    {
                        // Sets the Y direction to -1
                        Direction.Y = -1;
                    }
                }
                // else if the Current key pressed is the Down Arrow than this is true
                else if (keyboardstate.IsKeyDown(Keys.Down))
                {
                    // if the current Y velocity is greater than 0 and less than 10 then this is trye
                    if (Direction.Y > 0 && Direction.Y < 10)
                    {
                        // Increments Y direction by 1
                        Direction.Y += 1F;
                    }
                    else
                    {
                        // Sets the Y Direction to 1
                        Direction.Y = 1;
                    }
                }
                else
                {
                    // Sets Y direction to 0
                    Direction.Y = 0;
                }
            }
            // returns the direction
            return Direction;
        }
    }
}
