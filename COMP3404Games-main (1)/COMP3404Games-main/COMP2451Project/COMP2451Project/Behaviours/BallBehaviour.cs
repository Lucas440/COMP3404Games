using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project.Behaviours
{
    /// <summary>
    /// AUTHOR: Flynn Osborne & Lucas Brennan
    /// DATE: 24/01/2022
    /// </summary>
    class BallBehaviour: PongBehaviour, IUpdateListener
    {
        public override Vector2 Velocity { get => _velocity; }

        public BallBehaviour()
        {
            _velocity = new Vector2();
        }

        public override void OnUpdate(Object sender, UpdateEventArgs UpdateEventArgs) 
        {    
            if (UpdateEventArgs.ActiveBehaviour.ToLower() == "serve")
            {
                // DECLARES a float called Rotation
                float Rotation;

                // DECLARES a random variable called rnd
                Random rnd = new Random();

                // Randomizes a number which determines the angle of travel
                Rotation = (float)(Math.PI / 2 + (rnd.NextDouble() * (Math.PI / 1.5f) - Math.PI / 3));

                // Uses the sin of rotation to determine the x velocity
                _velocity.X = (float)Math.Sin(Rotation);
                // uses the cos of rotation to determine the y velocity
                _velocity.Y = (float)Math.Cos(Rotation);

                // Randomly generates a number between 0 and 1. If it is 1, then this is true:
                if (rnd.Next(0, 2) == 1)
                {
                    // The ball will move to the left
                    _velocity.X *= -1;
                }
            }
        
        
        }
    }
}
