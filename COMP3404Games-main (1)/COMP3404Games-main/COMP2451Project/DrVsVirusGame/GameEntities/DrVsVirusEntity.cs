using Engine.EngineEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Authors Lucas Brennan , Flynn Osborne & Will Eardley
/// 
/// Date 14/03/2022
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class that represents the A DrVsVirus entity
    /// </summary>
    public class DrVsVirusEntity : Entity, ICollidable
    {
        //DECLARE a Rectangle called _hitBox
        protected Rectangle _hitBox;
        //DECLARE a Texture2D called _texture
        protected Texture2D _texture;

        /// <summary>
        /// A Method which sets the screens boundarys
        /// </summary>
        /// <param name="pHight">The hight of the screen</param>
        /// <param name="pWidth">The Width of the Screen</param>
        public void setBoundaries(double pHight , double pWidth) 
        {
            //Sets _screenHight to pHight
            _screenHight = pHight;
            //Sets _screenWidth to pWidth
            _screenWidth = pWidth;
        }
        /// <summary>
        /// A Method that returns the HitBox
        /// </summary>
        /// <returns>The objects hitbox</returns>
        public Rectangle getHitBox() 
        {
            return _hitBox;
        }
        /// <summary>
        /// A Method that responds to colision
        /// </summary>
        public virtual void colision() { }
    }
}
