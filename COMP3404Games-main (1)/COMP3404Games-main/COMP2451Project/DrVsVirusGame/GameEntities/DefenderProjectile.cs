using Engine.EngineEntitys;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 28/03/22
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class used to represent a Defenders Projectile
    /// </summary>
    public class DefenderProjectile : Friendly
    {
        //DECLARE a Vector2 called _startLocn
        private Vector2 _startLocn;
        //DECLARE a bool called _isMoving
        private bool _isMoving;
        /// <summary>
        /// A Property used to Set if the Projectile is moving
        /// </summary>
        public bool Moving { set {_isMoving = value; } }
        /// <summary>
        /// A Property that sets the YLocn
        /// </summary>
        public int SetY { set { _entityLocn.Y = value; } }

        /// <summary>
        /// The Default Constructor
        /// </summary>
        public DefenderProjectile() 
        {
            //Set _isMoving to false
            _isMoving = false;

            //Sets _damage to 50
            _damage = 50;
        }
        /// <summary>
        /// A Method used to set the starting location of the object
        /// </summary>
        /// <param name="pLocn">The location they are starting at</param>
        public override void StartingLocation(Vector2 pLocn)
        {
            //Calls the base class
            base.StartingLocation(pLocn);
            //Sets _startLocn to pLocn
            _startLocn = pLocn;
        }
        /// <summary>
        /// A Method used to update the entity
        /// </summary>
        public override void update()
        {
            //Updates the base class
            base.update();
            //If _isMoving is true this is true
            if (_isMoving == true) 
            {
                //Increments the xPosition by 5
                _entityLocn.X+= 5;
                //If the xPosition is greater than _screenWidth this is true
                if (_entityLocn.X > _screenWidth) 
                {
                    //Sets the position back to _startLocn
                    _entityLocn = _startLocn;
                    //Sets _isMoving to false
                    _isMoving = false;
                }
            }
        }
        /// <summary>
        /// A Method used to respond to colision 
        /// </summary>
        /// <param name="pCollidedEntity">The Entity that is collided with</param>
        public override void colision(ICollidable pCollidedEntity)
        {
            //If the collied entity is an enemy this is true
            if (pCollidedEntity is Enemy) 
            {
                //Returns it to the starting location
                _entityLocn = _startLocn;
                //Sets _isMoving to false
                _isMoving = false;
            }
        }

        /// <summary>
        /// A Method which removes this object
        /// </summary>
        public void Remove()
        {
            //Scedule commands to Remove and Terminate this
            ScheduleCommand.Invoke(RemoveMe);
            ScheduleCommand.Invoke(TerminateMe);
        }
    }
}
