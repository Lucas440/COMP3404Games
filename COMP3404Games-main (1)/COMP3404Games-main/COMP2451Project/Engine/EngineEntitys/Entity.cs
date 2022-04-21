using Engine.Behaviours;
using Engine.Command;
using Engine.EngineStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
/// <summary>
/// AUTHORS: Lucas Brennan & Flynn Osborne
/// DATE: 07/02/2022
/// </summary>
namespace Engine.EngineEntitys
{
    /// <summary>
    /// A class used to represent the game's entities
    /// </summary>
    public abstract class Entity : IEntity, IEntityInternal, ICommandSender
    {
        // DECLARE a variable to hold the entity's behaviour
        protected IBehaviour _behaviour;

        // DECLARE a variable to hold the entity's current state
        protected IState _state;

        // CREATE a vector called ballLocn
        protected Vector2 _entityLocn;

        // DECLARE a double called _screenWidth
        protected double _screenWidth;
        // DECLARE a double called _screenHight
        protected double _screenHight;




        // Texture2D for spritesheet image
        protected Texture2D _spriteSheet;

        // REFERENCE - https://www.industrian.net/tutorials/using-sprite-sheets/
        // Timer for animation speed
        protected float _animationTimer;

        // Threshold for speed
        protected int _threshold;

        // Array to break down spritesheet into segments
        // REFERENCE - https://www.industrian.net/tutorials/using-sprite-sheets/
        protected Rectangle[] _movingRectangles;
        protected Rectangle[] _attackingRectangles;
        protected Rectangle[] _deathRectangles;

        // REFERENCE - https://www.industrian.net/tutorials/using-sprite-sheets/
        // Previous index in animation sequence
        protected byte _previousAnimationIndex;
        // Current index in animation sequence
        protected byte _currentAnimationIndex;






        /// <summary>
        /// A method that updates the entity on each loop
        /// </summary>
        public virtual void update() { }

        /// <summary>
        /// A property that returns the object's Position
        /// </summary>
        public Vector2 Position { get => _entityLocn; }

        /// <summary>
        /// A property that returns the object's state as a text
        /// </summary>
        public string StateText { get; set; }



        /// <summary>
        /// A method that changes the entity's state 
        /// </summary>
        /// <param name="pState">The state the entity must change to</param>
        public virtual void SetState(IState pState)
        {
            _state = pState;
        }

        //----------------------------------------------------------------- ICommandSender Implementation ----------------------------------

        /// <summary>
        /// A property used to set a ScheduleCommand action
        /// </summary>
        public Action<ICommand> ScheduleCommand { get; set; }

        // ---------------------------------------------------- IEntityInternal Implementation -------------------------------------------

        /// <summary>
        /// A property used to store a Terminate Method
        /// </summary>
        public ICommand TerminateMe { get; set; }

        /// <summary>
        /// A property used to Store a Remove Method
        /// </summary>
        public ICommand RemoveMe { get; set; }

    }
}
