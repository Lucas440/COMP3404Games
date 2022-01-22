using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project.Command
{
    public interface ICommandSender
    {
        Action<ICommand> ScheduleCommand { get; set; }
    }
}
