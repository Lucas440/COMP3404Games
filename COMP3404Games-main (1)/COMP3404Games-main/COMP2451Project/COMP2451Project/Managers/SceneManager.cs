using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace COMP2451Project
{
    /// <summary>
    /// CLASS 'SceneManager'
    /// MODIFIED BY: William Eardley 07/02/2022
    /// </summary>
    public class SceneManager
    {
        // DECLARE a new List called entityList
        List<IEntity> entityList;

        // DECLARE private variable '_sceneGraph' as type SceneGraph
        private SceneGraph _sceneGraph;

        // DECLARE a new double called screenWidth
        double ScreenWidth;

        // DECLARE a new double called screenHeight
        double ScreenHeight;

        /// <summary>
        /// CONSTRUCTOR 'SceneManager' - called upon Instantiation
        /// </summary>
        public SceneManager()
        {
            // INSTANTIATE entityList as new List
            entityList = new List<IEntity>();

            // INSTANTIATE  _sceneGraph as new SceneGraph
            _sceneGraph = new SceneGraph();
        }

        /// <summary>
        /// Method 'Initialise' - Initialises Scene Manager
        /// </summary>
        public void Initialise()
        {
            // CALL Initialise inside SceneGraph class - passing entityList
            _sceneGraph.Initialise(entityList);
        }

        /// <summary>
        /// Adds an Entity to the list
        /// </summary>
        /// <param name="entity">An IEntity to be stored</param>
        public void addEntity(IEntity entity)
        {
            // ADD entity parameter passed through to entityList
            entityList.Add(entity);
        }

        /// <summary>
        /// Updates the items in the list
        /// </summary>
        /// <param name="pHeight">Screen Height</param>
        /// <param name="pWidth">Screen Width </param>
        /// <returns>A list of entitys</returns>
        public void update(double pHeight, double pWidth)
        {
            // SET ScreenWidth to pWidth
            ScreenWidth = pWidth;
            
            // SET screenHeight to pHeight
            ScreenHeight = pHeight;
            
            // FOR LOOP which loops over each item in the array
            for (int i = 0; i < entityList.Count; i++)
            {
                // CALL Update for each entity in the entityList
                entityList[i].update();

                // CALL the SetBoundaries method - passing the screenWidth and ScreenHeight
                ((ICollidable)entityList[i]).setBoundaries(ScreenWidth, ScreenHeight);
            }
        }

        /// <summary>
        /// Draws the Entitys on the screen
        /// </summary>
        /// <param name="spriteBatch">A spritebatch used to draw</param>
        public void draw(SpriteBatch spriteBatch)
        {
            // CALL Draw method inside SceneGraph
            _sceneGraph.Draw(spriteBatch);
        }
    }
}
