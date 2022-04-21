using Engine.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author Lucas Brennan
/// 
/// Date 21/04/22
/// </summary>
namespace DrVsVirusGame.GameStates.EnemyStates
{
    /// <summary>
    /// A Class that represents the state that bactreia is in
    /// </summary>
    public class BacteriaState : DrVsVirusState
    {
        // DECLARE a new string called _identifier
        private string _identifier;

    /// <summary>
    /// The recommended constructor for BacteriaState
    /// </summary>
    /// <param name="pIdentifier">The Default identifier string</param>
    public BacteriaState(string pIdentifier)
    {
        // SET the identifier to pIdentifier
        _identifier = pIdentifier;
    }

    /// <summary>
    /// A Method used to respond to collision
    /// </summary>
    public override void Collide()
    {
        // TRIGGER _behaviour's OnCollision method
        Behaviour.OnCollision(_entity, new UpdateEventArgs { ActiveBehaviour = "" });
    }
    /// <summary>
    /// A Method used to update the state
    /// </summary>
    public override void Update()
    {
        // Trigger _behaviour's OnUpdate method
        Behaviour.OnUpdate(_entity, new UpdateEventArgs { ActiveBehaviour = _identifier });
    }
}
}
