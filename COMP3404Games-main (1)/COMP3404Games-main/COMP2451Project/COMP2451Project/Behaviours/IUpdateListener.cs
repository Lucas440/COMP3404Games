using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2451Project.Behaviours
{
    public interface IUpdateListener
    {
        void OnUpdate(object sender, UpdateEventArgs args);
    }
}
