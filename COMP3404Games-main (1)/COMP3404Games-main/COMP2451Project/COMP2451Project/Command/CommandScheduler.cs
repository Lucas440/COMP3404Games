using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project
{
    public class CommandScheduler : ICommandScheduler
    {
        public void ExecuteCommand(Action pAction) 
        {
            pAction.Invoke();
        }
    }
}
