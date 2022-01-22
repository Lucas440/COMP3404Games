using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project.Entities
{
    public interface IEntityInternal
    {
        ICommand TerminateMe { get; set; }
        ICommand RemoveMe { get; set; }
    }
}
