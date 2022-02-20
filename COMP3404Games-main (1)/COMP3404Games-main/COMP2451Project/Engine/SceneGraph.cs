using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.EngineEntitys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 14/02/22
/// </summary>
namespace Engine
{
    /// <summary>
    /// PUBLIC CLASS 'SceneGraph'
    /// AUTHOR: William Eardley 07/02/2022
    /// </summary>
    public class SceneGraph
    {
        // DECLARE variable '_entityList' as type IEntity - List to store entities
        private List<IEntity> _entityList;

        /// <summary>
        /// CONSTRUCTOR for 'SceneGraph' - Called upon creation
        /// </summary>
        public SceneGraph()
        {
            // INSTANTIATE _entityList as new List
            _entityList = new List<IEntity>();
        }

        /// <summary>
        /// METHOD 'Initialise' - Initialises SceneGraph
        /// </summary>
        public void Initialise(List<IEntity> plist)
        {
            // SET _entityList to pList parameter
            _entityList = plist;
        }

        /// <summary>
        /// METHOD 'Draw' - Draws entities to display
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            // FOR LOOP which loops each time through the _entityList array 
            for (int i = 0; i < _entityList.Count; i++)
            {
                // TRY CATCH
                try
                {
                    // CALL Draw method for each IDrawable entity in the _entityList
                    spriteBatch.Draw(((EngineEntitys.IDrawable)_entityList[i]).texture(), _entityList[i].position(), Color.AntiqueWhite);
                }
                // IF TRY fails then throw exception
                catch (Exception e) { }
            }
        }
        /// <summary>
        /// A method used to remove an entity from the scene graph
        /// </summary>
        /// <param name="pEntity">The entity being removed</param>
        public void Remove(IEntity pEntity) 
        {
            //Removes pEntity from the list
            _entityList.Remove(pEntity);
        }
    }
}
