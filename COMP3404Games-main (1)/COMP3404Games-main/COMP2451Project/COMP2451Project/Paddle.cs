using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace COMP2451Project
{
    class Paddle : PongEntity
    {
        //DECLARES an int called speed
        int speed;
        //DECLARES a vector2 called currentDirection
        Vector2 CurrentDirection;

        //DECLARES a PlayerIndex variable that stores which player is controlling this paddle
        PlayerIndex index;

        /// <summary>
        /// Is the Constructor for the Paddle
        /// </summary>
        /// <param name="paddleLocation">Passes the paddles Location</param>
        /// <param name="pIndex">Passes which player is controlling this paddle</param>>
        public Paddle(Vector2 paddleLocation , PlayerIndex pIndex) 
        {
            //INITALZIES objectType in the parent class
            objectType = "paddle";
            //INITALZIES entitylocn in the parent class
            EntityLocn = paddleLocation;
            // INTIALIZES speed to 5
            speed = 5;
            // Sets the index to player passed
            index = pIndex;
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
            //INITALIZES currentDirection to direction
            CurrentDirection = Input.GetKeyBoardInputDirection(index ,CurrentDirection);

            // if currentDirections y is less than 0 than this is true
            if (CurrentDirection.Y < 0)
            {
                // subtracts speed minus the currentDirections y from the y position
                EntityLocn.Y -= (speed - CurrentDirection.Y);
            }
            // else if current directions y is greater than 0
            else if (CurrentDirection.Y > 0) 
            {
                // adds speed plus currentdirections y to the y position
                EntityLocn.Y += speed + CurrentDirection.Y;
            }

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
    }
}
