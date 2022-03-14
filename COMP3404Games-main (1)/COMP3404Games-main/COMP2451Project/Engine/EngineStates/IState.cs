using Engine.EngineEntitys;

namespace Engine.EngineStates
{
    // AUTHOR: Flynn Osborne
    // DATE: 31/01/2022

    public interface IState
    {
        /// <summary>
        /// The method used to update the entity's state
        /// </summary>
        void Update();

        /// <summary>
        /// The method triggered when the entity collides
        /// </summary>
        void Collide();

        // A property to set an return a state's linked entity
        IEntity _entity { set; get; }
    }
}
