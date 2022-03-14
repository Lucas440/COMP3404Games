﻿using Engine.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Authors Lucas Brennan, Flynn Osborne & Will Eardley
/// 
/// Date 14/03/2022
/// </summary>
namespace DrVsVirusGame.GameBehaviours.EnemyBehaviour
{
    /// <summary>
    /// A Class that represents Virus' Behaviour
    /// </summary>
    public class VirusBehaviour : DrVsVirusBehaviour
    {
        /// <summary>
        /// A Method the responds to a updates
        /// </summary>
        /// <param name="sender">The object that called the method</param>
        /// <param name="UpdateEventArgs">The Update Event Argument / Data</param>
        public override void OnUpdate(object sender, UpdateEventArgs UpdateEventArgs)
        {
            //Sets _location to the entitys position
            _location = _myEntity.position();
            //If the Argument is "moving" this is true
            if (UpdateEventArgs.ActiveBehaviour.ToLower() == "moving") 
            {
                //_location is reduced by 1
                _location.X--;
            }
        }
    }
}