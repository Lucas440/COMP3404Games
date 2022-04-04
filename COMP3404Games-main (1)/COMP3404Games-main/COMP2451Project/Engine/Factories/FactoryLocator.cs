using System;
using System.Collections.Generic;
/// <summary>
/// AUTHOR: Flynn Osborne
/// DATE: 19/01/2022
/// </summary>
namespace Engine.Factories
{

    /// <summary>
    /// A class used to get factory services
    /// </summary>
    public class FactoryLocator : IFactoryLocator
    {
        // DECLARE a dictionary to hold all the factories
        private Dictionary<Type, IService> _factoryRegister;

        // Constructor for the factoryLocator
        public FactoryLocator()
        {
            // INITIALISE the factory dictionary
            _factoryRegister = new Dictionary<Type, IService>();
        }

        // Returns a factory of the required class
        public IService Get<T>() where T : class
        {
            // CREATE a factory if one does not already exist
            if (!_factoryRegister.ContainsKey(typeof(T)))
            {
                _factoryRegister.Add(typeof(T), new Factory<T>());
                
                // RETURN the created factory
                return _factoryRegister[(typeof(T))];
            }
            else
            {
                // RETURN the required factory
                return _factoryRegister[(typeof(T))];
            }
        }
    }
}
