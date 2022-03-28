using Engine.EngineEntitys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace PongGame.Entities
{
    public abstract class PongEntity : Entity, ICollidable, Engine.EngineEntitys.IDrawable
    {

        //--------------------------------------------- IEntity Implementation ---------------------------------------------


        /// <summary>
        /// Returns the Type of object the Entity is
        /// </summary>
        /// <returns>objectType - What the object is</returns>
        public string getObjectType()
        {
            //Returns objectType
            return objectType;
        }

        /// <summary>
        /// Updates the entity on each loop
        /// </summary>
        public override void update()
        {
            createHitbox();
        }

        /// <summary>
        /// Draws the entity on screen
        /// </summary>
        public virtual void draw() { }
        /// <summary>
        /// Creates the Objects Hitbox
        /// </summary>
        /// <returns>hitBox - A retangle that is used for the objects hitbox</returns>
        /// 

        //--------------------------------------------- ICollidable Implementation ---------------------------------------------

        //DECLARES a retangle called hitBox
        protected Rectangle hitBox;

        //Creates a 2D Texture Varibable called _Entity
        protected Texture2D _Entity;


        public Rectangle createHitbox()
        {
            // Creates a hitbox using a retangle using the location and the dimentions of the entity
            hitBox = new Rectangle(Convert.ToInt32(_entityLocn.X), Convert.ToInt32(_entityLocn.Y), _Entity.Width, _Entity.Height);
            //Returns hitbox
            return hitBox;
        }

        /// <summary>
        /// Checks colision between the object and the wall
        /// </summary>
        /// <param name="width">The screens width</param>
        /// <param name="height">The screens Height</param>
        public virtual void checkWallColision() { }

        ///<summary>
        /// Sets the boundies of the screen
        /// </summary>
        /// <param name="width">The screens width</param>
        /// <param name="height">The screens Height</param>
        public void setBoundaries(double pWidth, double pHeight)
        {
            Width = pWidth;
            Height = pHeight;
        }

        /// <summary>
        /// A method that returns the entitys hitbox
        /// </summary>
        /// <returns>hitbox - the entitys hitbox stored in a retangle variable</returns>
        public Rectangle getHitBox()
        {
            return hitBox;
        }

        /// <summary>
        /// A method that responds to a colision
        /// </summary>
        public virtual void Colision(ICollidable pCollidedEntity) { }

        //--------------------------------------------------- IDrawable Implementation ---------------------------------------------


        //DECLARES a string called objectType
        protected string objectType;


        //DECLARES a double that stores the screens width
        protected double Width;
        //DECLARES a double that store the screens Height
        protected double Height;

        /// <summary>
        /// Gets the texture of the object
        /// </summary>
        /// <returns>the entitys texture</returns>
        public virtual Texture2D texture()
        {
            return _Entity;
        }

        /// <summary>
        /// Sets the objects texture to what is passed
        /// </summary>
        /// <param name="texture">The Objects Texture</param>
        public virtual void Content(Texture2D texture)
        {
            _Entity = texture;
        }

    }


}

