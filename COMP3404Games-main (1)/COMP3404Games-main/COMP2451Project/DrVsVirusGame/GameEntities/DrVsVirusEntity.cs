using Engine.EngineEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// AUTHORS: Lucas Brennan, Flynn Osborne & Will Eardley
/// DATE: 21/03/2022
/// </summary>
namespace DrVsVirusGame.GameEntities
{
    /// <summary>
    /// A Class that represents a DrVsVirus entity
    /// </summary>
    public abstract class DrVsVirusEntity : Entity, ICollidable, Engine.EngineEntitys.IDrawable
    {
        // DECLARE arrays to hold the columns and rows of the grid
        public int[] _gridX;
        public int[] _gridY;

        // DECLARE variables to hold the entity's current location in the grid
        public int gridXLocation;
        public int gridYLocation;
        //DECLARE an int called _HP
        protected int _HP;
        //DECLARE an int called _damage
        protected int _damage;
        
        /// <summary>
        /// Returns the amount of damge this entity does
        /// </summary>
        public int Damge { get => _damage; }

        /// <summary>
        /// A method which keeps track of the entity's location within the grid
        /// </summary>
        public virtual void UpdateGridLocation()
        {
            if (_entityLocn.X < _gridX[0] && _entityLocn.Y < _gridY[0])
            {
            }
            else
            {
                // Observes the horizontal grid position
                for (int i = 0; i < _gridX.Length - 1; i++)
                {
                    // Check each column to find the entity
                    if (_entityLocn.X >= _gridX[i] && _entityLocn.X < _gridX[i + 1])
                    {
                        // Set the horizontal grid location and break the loop
                        gridXLocation = i + 1;
                        break;
                    }
                    else
                    {
                        // Confirm that the entity is in the last column
                        gridXLocation = _gridX.Length;
                    }
                }

                // Observes the vertical grid position
                for (int i = 0; i < _gridY.Length - 1; i++)
                {
                    // Check each row to find the entity
                    if (_entityLocn.Y >= _gridY[i] && _entityLocn.Y < _gridY[i + 1])
                    {
                        // Set the vertical grid location and break the loop
                        gridYLocation = i + 1;
                        break;
                    }
                    else
                    {
                        // Confirm that the entity is in the last row
                        gridYLocation = _gridY.Length;
                    }
                }
            }

            // Updates the entity's StateText to output the current grid position
            //StateText = "Current Grid X: " + gridXLocation + " Current Grid Y: " + gridYLocation;
        }

        // -------------------------------------------------------- ICollidable Implemation -------------------------------------------------------------
        // DECLARE a Rectangle called _hitBox
        protected Rectangle _hitBox;
        //DECLARE a Texture2D called _texture
        protected Texture2D _texture;

        /// <summary>
        /// A Method which sets the screen's boundaries
        /// </summary>
        /// <param name="pHight">The height of the screen</param>
        /// <param name="pWidth">The width of the screen</param>
        public virtual void setBoundaries(double pWidth ,double pHight) 
        {
            // SETS _screenHight to pHight
            _screenHight = pHight;
            // SETS _screenWidth to pWidth
            _screenWidth = pWidth;

        }
        /// <summary>
        /// A Method that returns the HitBox
        /// </summary>
        /// <returns>The objects hitbox</returns>
        public virtual Rectangle getHitBox() 
        {
            // CREATES a new Rectangle based on the entity's location and the dimensions of the texture
            _hitBox = new Rectangle(Convert.ToInt32(_entityLocn.X), Convert.ToInt32(_entityLocn.Y), _texture.Width, _texture.Height);

            // RETURNS the hitbox
            return _hitBox;
        }
        /// <summary>
        /// A Method that responds to collision
        /// </summary>
        public virtual void colision(ICollidable pCollidedEntity) { }

        // --------------------------------------------------------- IDrawable Implementaion ----------------------------------------------------------------------------

        /// <summary>
        /// A Method used to set the texture of the entity
        /// </summary>
        /// <param name="pTexture">The Texture being set</param>
        public void Content(Texture2D pTexture) 
        {
            // SETS _texture to pTexture
            _texture = pTexture;
        }

        /// <summary>
        /// A Method that draws the object onto the screen
        /// </summary>
        public void draw() { }

        /// <summary>
        /// A Method that returns the object's texture
        /// </summary>
        /// <returns></returns>
        public Texture2D texture() 
        {
            // RETURNS the texture
            return _texture;
        }

        // ---------------------------------------------------- DrVsVirusEntity Implmentation ----------------------------------------------------------------

        /// <summary>
        /// A Method that sets the starting location of the entity
        /// </summary>
        /// <param name="pLocn">The location of the entity</param>
        public virtual void StartingLocation(Vector2 pLocn) 
        {
            // SET the entity's starting location
            _entityLocn = pLocn;
        }

        /// <summary>
        /// A method that passes the grid to the entity
        /// </summary>
        /// <param name="pGridX">The array of columns</param>
        /// <param name="pGridY">The array of rows</param>
        public virtual void SetGrid(int[] pGridX, int[] pGridY)
        {
            // SET the rows and columns of the grid
            _gridX = pGridX;
            _gridY = pGridY;
        }
    }
}
