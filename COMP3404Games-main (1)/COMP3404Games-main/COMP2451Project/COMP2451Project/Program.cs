using Engine;
using Engine.Factories;
using Engine.Managers;
using System;

namespace COMP2451Project
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// MODIFIED BY: Will Eardley 30/01/22
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // DECLARE variable '_factoryLocator' as type IFactoryLocator - for passing through EngineManager
            IFactoryLocator _factoryLocator = new FactoryLocator();

            // DECLARE variable '_engineManager' as type EngineManager
            EngineManager _engineManager = new EngineManager(_factoryLocator);

            // INSTANTIATE 'Kernel' passing through Engine Manager
            using (var game = new kernel(_engineManager))
                game.Run();
        }
    }
#endif
}
