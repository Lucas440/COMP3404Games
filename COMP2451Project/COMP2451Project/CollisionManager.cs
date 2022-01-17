using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// AUTHOR: Flynn Osborne
/// DATE: 13/12/2021
/// </summary>
namespace COMP3451Project.Managers
{
    class CollisionManager
    {
        // List of entities
        public List<Entity> entities;

        public CollisionManager()
        {
            // Instantiate list of entities
            entities = new List<Entity>();
        }

        public void Update()
        {
            // Iterate through list, checking pairs for collision
            for (int i = 0; i < entities.Count; i++)
            {
                for (int j = i + 1; j < entities.Count; j++)
                {
                    if (entities[i].HitBox.Intersects(entities[j].HitBox))
                    {
                        entities[i].OnCollide(entities[j]);
                    }
                }
            }
        }

        public void Initialise(List<Entity> pEntities)
        {
            // Set entity list
            entities = pEntities;
        }

    }
}
