using DrVsVirusGame.GameEntities;
using Engine.EngineEntitys;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
/// <summary>
/// AUTHOR: Lucas Brennan
/// DATE: 28/03/22
/// </summary>
namespace Engine.Managers
{
    /// <summary>
    /// A class used to detect any collisions between colibable objects
    /// </summary>
    class ColisionManager
    {
        // DECLARES an List Called entity that stores IEntitys
        IList<IEntity> _entityList;

        /// <summary>
        /// A method that stores a reference to the entity list
        /// </summary>
        /// <param name="pList">A reference to the entity</param>
        public void Initialize(IList<IEntity> pList)
        {
            _entityList = pList;
        }

        /// <summary>
        /// A method that updates the ColisionManager
        /// </summary>
        public void update()
        {
            // DECLARES and INSTANTIATES a list that stores IColliables called collidables
            List<ICollidable> collidables = new List<ICollidable>();

            // LOOP over each IEntity in the entity list
            foreach (IEntity e in _entityList)
            {
                // IF the entity is a ICollidable type:
                if (e is ICollidable)
                {
                    // ADD the item to the collidables list
                    collidables.Add((ICollidable)e);
                }
            }

            // LOOP over each item on the list
            for (int i = 0; i < collidables.Count(); i++)
            {
                // LOOP ahead by one item
                for (int j = i + 1; j < collidables.Count(); j++)
                {
                    if (((collidables[i] is Frendly) && (collidables[j] is Enemy))
                        || ((collidables[i] is Enemy) && (collidables[j] is Frendly))) 
                    {
                        // IF the current items' hitboxs are intersecting:
                        if (collidables[i].getHitBox().Intersects(collidables[j].getHitBox()))
                        {
                            // CALL collision on each object
                            collidables[i].colision(collidables[j]);
                            collidables[j].colision(collidables[i]);
                        } 
                    }
                }
            }
        }
    }
}
