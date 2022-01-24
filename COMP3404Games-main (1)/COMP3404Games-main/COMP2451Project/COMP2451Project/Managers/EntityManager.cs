using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP2451Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
/// <summary>
/// AUTHOR: Flynn Osborne
/// DATE: 17/01/2022
/// </summary>
namespace COMP3451Project.Managers
{
    public class EntityManager
    {
        // Variable to hold game entity
        public IEntity entity;

        // List to hold the entities
        public List<IEntity> entities;

        public EntityManager() 
        {
            entities = new List<IEntity>();
        }

        public IEntity CreateEntity(int pEntityType , Vector2 pLocation , Texture2D pTexture)
        {
            // pOrderNumber dictates which entity will be instantiated

            // 0 = Player
            // 1 = Secretary
            /*
            if (pOrderNumber == 0)
            {
                // Instantiate the player
                entity = new Player(500, 500, pScreenHeight, pScreenWidth, pSpriteBatch);
            }
            else if (pOrderNumber == 1)
            {
                // Instantiate the secretary
                entity = new Secretary(1200, 700, pScreenHeight, pScreenWidth, pSpriteBatch);
            }
            */
            // Return the chosen entity


            //DECLARES a new IEntity called entity
            IEntity entity;
            //it pEntityType is 1 this is true
            if (pEntityType == 1)
            {
                //INTALISES entity as a new Paddle passing the location and player index
                 entity = new Paddle(pLocation, PlayerIndex.One);
                //Loads the content in the entity
                ((PongEntity)entity).Content(pTexture);
            }
            //if pEntityType is 2 this is true
            else if (pEntityType == 2) 
            {
                //INTALISES entity as a new Paddle passing the location and player index
                entity = new Paddle(pLocation, PlayerIndex.Two);
                //Loads the content in the entity
                ((PongEntity)entity).Content(pTexture);
            }

            else 
            {
                //INTALISES entity as a new Ball passing the location
                entity = new Ball(pLocation);
                //Loads the content in the entity
                ((PongEntity)entity).Content(pTexture);
            }
            //Adds the Entity to the List
            entities.Add(entity);
            //returns the entity
            return entity;
        }

        public List<IEntity> CreateEntityList()
        {
            // Reset the entity list



            // pOrderNumber dictates which list of entities will be instantiated

            // 0 = Patients
            // 1 = Top Walls
            // 2 = Top Walls (with doorway)
            // 3 = Bottom Walls
            // 4 = Bottom Walls (with doorway)
            // 5 = Left Walls
            // 6 = Left Walls (with doorway)
            // 7 = Right Walls
            // 8 = Right Walls (with doorway)
            /*
            if (pOrderNumber == 0)
            {
                // Instantiate the patients
                for (int i = 0; i < 3; i++)
                {
                    entity = new Patient(800, 300, pScreenHeight, pScreenWidth, pSpriteBatch);
                    entities.Add(entity);
                }
            }
            else if (pOrderNumber == 1)
            {
                // Instantiate the top walls
                for (int i = 0; i < 11; i++)
                {
                    entity = new WallHorizontal(150 * i, -150, pScreenHeight, pScreenWidth, pSpriteBatch);
                    entities.Add(entity);
                }
            }
            else if (pOrderNumber == 2)
            {
                // Instantiate the top walls (with doorway)
                for (int i = 0; i < 4; i++)
                {
                    entity = new WallHorizontal(150 * i, -200, pScreenHeight, pScreenWidth, pSpriteBatch);
                    entities.Add(entity);
                    entity = new WallHorizontal(pScreenWidth - (150 * i), -200, pScreenHeight, pScreenWidth, pSpriteBatch);
                    entities.Add(entity);
                }
            }
            else if (pOrderNumber == 3)
            {
                // Instantiate the bottom walls
                for (int i = 0; i < 11; i++)
                {
                    entity = new WallHorizontal(150 * i, pScreenHeight + 500, pScreenHeight, pScreenWidth, pSpriteBatch);
                    entities.Add(entity);
                }
            }
            else if (pOrderNumber == 4)
            {
                // Instantiate the bottom walls (with doorway)
                for (int i = 0; i < 4; i++)
                {
                    entity = new WallHorizontal(150 * i, pScreenHeight + 500, pScreenHeight, pScreenWidth, pSpriteBatch);
                    entities.Add(entity);
                    entity = new WallHorizontal(pScreenWidth - (150 * i), pScreenHeight + 500, pScreenHeight, pScreenWidth, pSpriteBatch);
                    entities.Add(entity);
                }
            }
            else if (pOrderNumber == 5)
            {
                // Instantiate the left walls
                for (int i = 0; i < 6; i++)
                {
                    entity = new WallVertical(-100, 150 * i, pScreenHeight, pScreenWidth, pSpriteBatch);
                    entities.Add(entity);
                }
            }
            else if (pOrderNumber == 6)
            {
                // Instantiate the left walls (with doorway)
                for (int i = 0; i < 2; i++)
                {
                    entity = new WallVertical(-100, 150 * i, pScreenHeight, pScreenWidth, pSpriteBatch);
                    entities.Add(entity);
                    entity = new WallVertical(-100, pScreenHeight - (150 * i), pScreenHeight, pScreenWidth, pSpriteBatch);
                    entities.Add(entity);
                }
            }
            else if (pOrderNumber == 7)
            {
                // Instantiate the right walls
                for (int i = 0; i < 6; i++)
                {
                    entity = new WallVertical(pScreenWidth + 500, 150 * i, pScreenHeight, pScreenWidth, pSpriteBatch);
                    entities.Add(entity);
                }
            }
            else if (pOrderNumber == 8)
            {
                // Instantiate the right walls (with doorway)
                for (int i = 0; i < 2; i++)
                {
                    entity = new WallVertical(pScreenWidth + 500, 150 * i, pScreenHeight, pScreenWidth, pSpriteBatch);
                    entities.Add(entity);
                    entity = new WallVertical(pScreenWidth + 500, pScreenHeight - (150 * i), pScreenHeight, pScreenWidth, pSpriteBatch);
                    entities.Add(entity);
                }
            }
            */
            // Return the entity list
            return entities;
        }
    }
}
