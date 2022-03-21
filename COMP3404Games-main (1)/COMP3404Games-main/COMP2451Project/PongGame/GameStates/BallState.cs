using Engine.Behaviours;


namespace PongGame.States
{
    // AUTHOR: Flynn Osborne
    // DATE: 31/01/2022

    public class BallState : PongState
    {
        /// <summary>
        /// The method used to update the ball's state
        /// </summary>
        public override void Update()
        {
            // Triggers the ball's update behaviour
            Behaviour.OnUpdate(_entity, new UpdateEventArgs() { ActiveBehaviour = "" });
        }

        /// <summary>
        /// The method triggered when the ball has a collision
        /// </summary>
        public override void Collide()
        {
            // Triggers the ball's collision behaviour
            Behaviour.OnCollision(_entity, new UpdateEventArgs() { ActiveBehaviour = "" });
        }
    }
}
