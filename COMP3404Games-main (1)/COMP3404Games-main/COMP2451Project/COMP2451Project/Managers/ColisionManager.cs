﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project
{
    class ColisionManager
    {
        //DECLARES an List Called entity that stores IEntitys
        List<IEntity> entity;
        /// <summary>
        /// A method that stores a reference to the entity list
        /// </summary>
        /// <param name="pList">A reference to the entity</param>
        public void Initialize(List<IEntity> pList) 
        {
            entity = pList;
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
            foreach (IEntity e in entity) 
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