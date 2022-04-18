using Engine.EngineEntitys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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
        private IList<IEntity> _entityList;
        //DECLARE variable _spriteFont to store the font of the program
        private SpriteFont _spriteFont;

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
        /// <param name="plist">The List of entitys to draw</param>
        /// <param name="pSpriteFont">A font for text</param>
        public void Initialise(IList<IEntity> plist, SpriteFont pSpriteFont)
        {
            // SET _entityList to pList parameter
            _entityList = plist;
            //SET _sprteFont to pSpriteFont parameter
            _spriteFont = pSpriteFont;
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
                    //If the texture is not null this is true
                    if (((EngineEntitys.IDrawable)_entityList[i]).texture() != null) {
                        // CALL Draw method for each IDrawable entity in the _entityList
                        spriteBatch.Draw(((EngineEntitys.IDrawable)_entityList[i]).texture(), _entityList[i].Position, Color.AntiqueWhite);
                    }
                    else 
                    {
                        //Draws text on the screen for the current entity
                        spriteBatch.DrawString(_spriteFont, _entityList[i].StateText, new Vector2(_entityList[i].Position.X, _entityList[i].Position.Y), Color.Black);
                    }
                    /*
                    //If the x position is less than 700 this is true
                    if (_entityList[i].Position.X < 700)
                    {
                        //Draws text on the screen for the current entity
                        spriteBatch.DrawString(_spriteFont, _entityList[i].StateText, new Vector2(_entityList[i].Position.X, 800), Color.Black);
                    }
                    else
                    {
                        //Draws text on the screen for the current entity
                        spriteBatch.DrawString(_spriteFont, _entityList[i].StateText, new Vector2(_entityList[i].Position.X - 200, 800), Color.Black);
                    }
                    */
                    
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
