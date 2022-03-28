using Engine.EngineEntitys;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 14/02/22
/// </summary>
namespace Engine.Managers
{
    /// <summary>
    /// CLASS: 'SceneManager'
    /// MODIFIED BY: William Eardley 07/02/2022
    /// </summary>
    public class SceneManager
    {
        // DECLARE a new List called entityList
        private List<IEntity> _entityList;

        // DECLARE a private variable '_sceneGraph' as type SceneGraph
        private SceneGraph _sceneGraph;

        // DECLARE a new double called screenWidth
        private double _screenWidth;

        // DECLARE a new double called screenHeight
        private double _screenHeight;

        /// <summary>
        /// CONSTRUCTOR 'SceneManager' - called upon Instantiation
        /// </summary>
        public SceneManager()
        {
            // INSTANTIATE entityList as a new List
            _entityList = new List<IEntity>();

            // INSTANTIATE  _sceneGraph as a new SceneGraph
            _sceneGraph = new SceneGraph();
        }

        /// <summary>
        /// Method 'Initialise' - Initialises the Scene Manager
        /// </summary>
        /// <param name="pSpriteFont">A Font for text</param>
        public void Initialise(SpriteFont pSpriteFont)
        {
            // CALL Initialise inside SceneGraph class - passing entityList and the SpriteFont
            _sceneGraph.Initialise(_entityList, pSpriteFont);
        }

        /// <summary>
        /// Adds an Entity to the list
        /// </summary>
        /// <param name="entity">An IEntity to be stored</param>
        public void AddEntity(IEntity entity)
        {
            // ADD the entity to the list of entities
            _entityList.Add(entity);
        }

        /// <summary>
        /// A method that updates the items in the list
        /// </summary>
        /// <param name="pHeight">Screen Height</param>
        /// <param name="pWidth">Screen Width </param>
        /// <returns>A list of entitys</returns>
        public void Update(double pHeight, double pWidth)
        {
            // SET ScreenWidth to pWidth
            _screenWidth = pWidth;

            // SET screenHeight to pHeight
            _screenHeight = pHeight;

            // FOR LOOP which loops over each item in the array
            for (int i = 0; i < _entityList.Count; i++)
            {
                // CALL Update for each entity in the entityList
                _entityList[i].update();

                // CALL the SetBoundaries method - passing the screenWidth and ScreenHeight
                ((ICollidable)_entityList[i]).setBoundaries(_screenWidth, _screenHeight);
            }
        }

        /// <summary>
        /// A method that draws the entities onto the screen
        /// </summary>
        /// <param name="spriteBatch">A spritebatch used to draw</param>
        public void draw(SpriteBatch spriteBatch)
        {
            // CALL the Draw method inside SceneGraph
            _sceneGraph.Draw(spriteBatch);
        }

        // -------------------------------------------------------- Command Pattern ----------------------------------------------------------
        /// <summary>
        /// A method used to remove an entity from the scene
        /// </summary>
        /// <param name="pEntity">The entity being removed</param>
        public void Remove(IEntity pEntity)
        {
            // CALL remove in _sceneGraph
            _sceneGraph.Remove(pEntity);

            // REMOVE pEntity from the entityList
            _entityList.Remove(pEntity);
        }
    }
}
