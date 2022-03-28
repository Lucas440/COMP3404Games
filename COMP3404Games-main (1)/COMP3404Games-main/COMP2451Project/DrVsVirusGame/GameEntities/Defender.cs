using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// CLASS 'Defender' - for defender entity
/// Author: William Eardley & Lucas Brennan
/// Date: 28/03/2022
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class used to represent the Defender entity
    /// </summary>
    public class Defender : DrVsVirusEntity
    {
        //DECLARE a EntitySight called _mySight
        private EntitySight _mySight;
        /// <summary>
        ///A Property used to Set the entity sight
        /// </summary>
        public EntitySight SetSight { set { _mySight = value; } }

        //DECLARE a DefenderProjectile called _myProjectile
        private DefenderProjectile _myProjectile;
        /// <summary>
        /// A Property used to set the Projectile
        /// </summary>
        public DefenderProjectile SetProjectile { set { _myProjectile = value; } }
        /// <summary>
        /// The Default constructor
        /// </summary>
        public Defender()
        {
            
        }
        /// <summary>
        /// A Method used to set the starting location of the entity
        /// </summary>
        /// <param name="pLocn">The starting location</param>
        public override void StartingLocation(Vector2 pLocn)
        {
            //Calls the base class
            base.StartingLocation(pLocn);

            //Callss StartingLocation for _myProjectile and _mySight
            _myProjectile.StartingLocation(pLocn);
            _mySight.StartingLocation(pLocn); 
        }
        /// <summary>
        /// A Method used to update the class
        /// </summary>
        public override void update()
        {
            //Calls the base class
            base.update();
            //If There is an enemy in sight this is true
            if (_mySight.EnemyInSight == true) 
            {
                //Starts the projectile moving
                _myProjectile.Moving = true;
            }
        }

    }
}
