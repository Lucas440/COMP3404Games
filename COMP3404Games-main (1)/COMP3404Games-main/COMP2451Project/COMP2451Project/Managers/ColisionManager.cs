using Engine.EngineEntitys;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 14/02/22
/// </summary>
namespace Engine.Managers
{
    /// <summary>
    /// A class used to detect any collisions between colibable objects
    /// </summary>
    class ColisionManager
    {
        //DECLARES an List Called entity that stores IEntitys
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
        /// <param name="pList">A List of entitys to be updated</param>
        public void update()
        {
            //DECLARES and INATANIATES a list that stores IColliables called collidables
            List<ICollidable> collidables = new List<ICollidable>();

            //Loops over each IEntity in the list Entity
            foreach (IEntity e in _entityList)
            {
                // If the entity is a ICollidable type
                if (e is ICollidable)
                {
                    //Adds the item to the collidables list
                    collidables.Add((ICollidable)e);
                }
            }

            // Loops over each item on the list
            for (int i = 0; i < collidables.Count(); i++)
            {
                // Loops ahead by one item
                for (int j = i + 1; j < collidables.Count(); j++)
                {
                    //If the current item in the loops hitboxs are intersecting
                    if (collidables[i].getHitBox().Intersects(collidables[j].getHitBox()))
                    {
                        //Call collision on each object
                        collidables[i].colision();
                        collidables[j].colision();
                    }
                }
            }
        }
    }
}
