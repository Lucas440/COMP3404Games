using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project
{
    // AUTHOR: Flynn Osborne
    // DATE: 19/01/2022

    public class FactoryLocator : IFactoryLocator
    {
        // Dictionary to hold all factories
        private Dictionary<Type, IService> _factoryRegister;

        // Constructor for the factoryLocator
        public FactoryLocator()
        {
            // Initialises the factory dictionary
            _factoryRegister = new Dictionary<Type, IService>();
        }

        // Returns a factory of the required class
        public IService Get<T>() where T : class
        {
            // Creates a factory if one does not already exist
            if (!_factoryRegister.ContainsKey(typeof(T)))
            {
                _factoryRegister.Add(typeof(T), new Factory<T>());

                return _factoryRegister[(typeof(T))];
            }
            else
            {
                return _factoryRegister[(typeof(T))];
            }
        }
    }
}
