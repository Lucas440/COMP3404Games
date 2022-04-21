using DrVsVirusGame.GameBehaviours.EnemyBehaviour;
using DrVsVirusGame.GameStates.EnemyStates;
using Engine.Behaviours;
using Engine.EngineEntitys;
using Engine.EngineStates;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Author Lucas Brennan
/// 
/// Date 21/04/22
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class that represents the Fungi Enemy
    /// </summary>
    public class Fungi : Enemy
    {

        //DECLARE a IState called _currentState
        IState _currentState;
        //DECLARE a IState called _movingState
        IState _movingState;

        // DECLARE a new event called _currentBehaviour
        public event OnUpdateEvent _currentBehaviour;

       

        /// <summary>
        /// The Default Constructor
        /// </summary>
        public Fungi() 
        {
            //Set the Hp to 100
            _HP = 200;

            //Sets _damage to 25
            _damage = 25;

            // INSTANTIATE _movingRectangles to get segments of sprite sheet
            _movingRectangles = new Rectangle[7];

            _movingRectangles[0] = new Rectangle(0, 0, 224, 224);
            _movingRectangles[1] = new Rectangle(192, 0, 224, 224);
            _movingRectangles[2] = new Rectangle(384, 0, 224, 224);
            _movingRectangles[3] = new Rectangle(576, 0, 224, 224);
            _movingRectangles[4] = new Rectangle(768, 0, 224, 224);
            _movingRectangles[5] = new Rectangle(960, 0, 224, 224);
            _movingRectangles[6] = new Rectangle(1152, 0, 224, 224);

            _previousAnimationIndex = 2;
            _previousAnimationIndex = 1;

            _animationTimer = 0;
            _threshold = 100;
        }

        /// <summary>
        /// A Delegate for an event which happens when the class is updated
        /// </summary>
        /// <param name="sender">The object that called the event</param>
        /// <param name="args">The event argument / data</param>
        public delegate void OnUpdateEvent(object sender, UpdateEventArgs args);



        /// <summary>
        /// A Method that sets the starting location of the Fungi
        /// </summary>
        /// <param name="pLocn">The StartingLocation (Not used in this method)</param>
        public override void StartingLocation(Vector2 pLocn)
        {
            // INITIALISE a new Random called rnd
            Random rnd = new Random();

            _entityLocn = pLocn;

            // INITIALISE class variables:
            //_behaviour
            _behaviour = new FungiBehaviour();
            ((Behaviour)_behaviour)._myEntity = this;
            //_movingState
            _movingState = new FungiState("Moving");
            // SETS _movingState's entity to this
            _movingState._entity = this;
            ((State)_movingState).Behaviour = _behaviour;
            //_currentState
            _currentState = _movingState;

            // ADDS _behaviour's OnUpdate Method to the event
            _currentBehaviour += _behaviour.OnUpdate;
        }

        /// <summary>
        /// Updates the Fungi
        /// </summary>
        public override void update()
        {
            // UPDATES the current state
            _currentState.Update();
            //sets the location to the behaviours location
            _entityLocn = _behaviour.Location;

            // IF the virus has gone beyond the left side of the screen
            if (_entityLocn.X < 0)
            {
                //Scedule a command that reduces lives
                ScheduleCommand.Invoke(ReduceLives);
                //Scedule commands to Remove and Terminate this
                ScheduleCommand.Invoke(RemoveMe);
                ScheduleCommand.Invoke(TerminateMe);

            }

            // OUTPUT the current grid location
            UpdateGridLocation();

            // Check if the timer has exceeded the threshold.
            if (_animationTimer > _threshold)
            {
                // If Alex is in the middle sprite of the animation.
                if (_currentAnimationIndex == 1)
                {
                    // If the previous animation was the left-side sprite, then the next animation should be the right-side sprite.
                    if (_previousAnimationIndex == 0)
                    {
                        _currentAnimationIndex = 2;
                    }
                    else
                    // If not, then the next animation should be the left-side sprite.
                    {
                        _currentAnimationIndex = 0;
                    }
                    // Track the animation.
                    _previousAnimationIndex = _currentAnimationIndex;
                }
                // If Alex was not in the middle sprite of the animation, he should return to the middle sprite.
                else
                {
                    _currentAnimationIndex = 1;
                }
                // Reset the timer.
                _animationTimer = 0;
            }
            // If the timer has not reached the threshold, then add the milliseconds that have past since the last Update() to the timer.
            else
            {
                // ERROR HERE - ANIMATION USES GAMETIME TO KEEP UP WITH ANIMATION SPEED
               // _animationTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            
            // NEEDS TO GO INTO DRAWING
            // _spriteBatch.Draw(_fungus, new Vector2(100, 100), _fungusMovingRectangles[currentAnimationIndex], Color.White);

            _entityLocn.Y = _gridY[gridYLocation - 1] + 25;
        }

        /// <summary>
        /// A Method that responds to collisions
        /// </summary>
        /// <param name="pCollidedEntity">The entity the object collided with</param>
        public override void colision(ICollidable pCollidedEntity)
        {
            //If the Collided entity is a Cannonball this is true
            if (pCollidedEntity is CannonBall || pCollidedEntity is DefenderProjectile)
            {
                //REDUCES the Hp by the amount of damage the entity does
                _HP -= ((DrVsVirusEntity)pCollidedEntity).Damge;
                //If _HP is less than 0
                if (_HP <= 0)
                {
                    //Alter the points the player has
                    ScheduleCommand.Invoke(AlterPoints);
                    //Scedule commands to Remove and Terminate this
                    ScheduleCommand.Invoke(RemoveMe);
                    ScheduleCommand.Invoke(TerminateMe);
                }
            }
        }
    }
}
