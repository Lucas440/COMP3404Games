using Engine.EngineEntitys;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 28/03/22
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class used to represent an Entity's Sight
    /// </summary>
    public class EntitySight : Friendly
    {
        // DECLARE a Bool called _enemyInSight
        private bool _enemyInSight;

        /// <summary>
        /// A Property used to Check if an Enemy is in sight
        /// </summary>
        public bool EnemyInSight { get => _enemyInSight; }

        /// <summary>
        /// The Default Constructor
        /// </summary>
        public EntitySight() 
        {
            // SET _enemyInSight To false
            _enemyInSight = false;
        }

        /// <summary>
        /// A Method that returns the objects hitbox
        /// </summary>
        /// <returns>The Hitbox of the object</returns>
        public override Rectangle getHitBox()
        {
            // CREATE a hitbox that streches acrros the screen
            _hitBox = new Rectangle((int)_entityLocn.X , (int)_entityLocn.Y , 1600 , 10);
            // RETURN _hitbox
            return _hitBox;
        }

        /// <summary>
        /// A Method that updates the entity
        /// </summary>
        public override void update()
        {
            // UPDATE the base class
            base.update();
            // SET _enemyInSight to false
            _enemyInSight = false;
        }

        /// <summary>
        /// A Method that responds to a colision
        /// </summary>
        /// <param name="pCollidedEntity">The entity that is being collided</param>
        public override void colision(ICollidable pCollidedEntity)
        {
            // IF the CollidedEntity is an Enemy:
            if (pCollidedEntity is Enemy) 
            {
                // SET _enemyInSight to true
                _enemyInSight = true;
            }
        }
        /// <summary>
        /// A Method which removes this object
        /// </summary>
        public void Remove() 
        {
            // SCHEDULE commands to Remove and Terminate this
            ScheduleCommand.Invoke(RemoveMe);
            ScheduleCommand.Invoke(TerminateMe);
        }
    }
}
