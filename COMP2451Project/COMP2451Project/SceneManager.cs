using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;

namespace COMP2451Project
{
    class SceneManager
    {
        //DECLARES a new List called entityList
        List<IEntity> entityList;

        //DECLARES a new double called screenWidth
        double ScreenWidth;
        //DECLARES a new double called screenHeight
        double ScreenHeight;
        /// <summary>
        /// The construtor for SceneManager
        /// </summary>
        public SceneManager() 
        {
            //INTIALZIES entityList
            entityList = new List<IEntity>();
        }
        /// <summary>
        /// Adds an Entity to the list
        /// </summary>
        /// <param name="entity">An IEntity to be stored</param>
        public void addEntity(IEntity entity) 
        {
            // Adds the entity passed through the
            entityList.Add(entity);
        }
        /// <summary>
        /// Updates the items in the list
        /// </summary>
        /// <param name="pHeight">Screen Height</param>
        /// <param name="pWidth">Screen Width </param>
        /// <returns>A list of entitys</returns>
        public void update(double pHeight , double pWidth) 
        {
            //Sets ScreenWidth to pWidth
            ScreenWidth = pWidth;
            //Sets screenHeight to pHeight
            ScreenHeight = pHeight;
            // Loops over each item in the array
            for (int i = 0; i < entityList.Count; i++)
            {
                // calls update
                entityList[i].update();
                // calls the set boundies method passing the screenWidth and ScreenHeight
                ((ICollidable)entityList[i]).setBoundaries(ScreenWidth, ScreenHeight);
            }
        }
        /// <summary>
        /// Draws the Entitys on the screen
        /// </summary>
        /// <param name="spriteBatch">A spritebatch used to draw</param>
        public void draw(SpriteBatch spriteBatch) 
        {
            // loops over each item in the list
            for (int i = 0; i < entityList.Count; i++)
            {
                try
                {
                    // Draws the entity on the screen
                    spriteBatch.Draw(((IDrawable)entityList[i]).texture(), entityList[i].position(), Color.AntiqueWhite);
                }
                catch(Exception e) { }
            }
        }
    }
}
