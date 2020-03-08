using GoF.AssemblyItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.CoR
{
    public class GlueStation : AssemblyHandlerBase
    {
        public GlueStation() : base() { }
        public GlueStation(AssemblyHandlerBase successor) : base(successor) { }
        public override void HandleRequest(AssemblyItem item)
        {
            if (item.RequiresTask(WorkType.GlueWork))
                item.PerformTask(new Work(10, WorkType.GlueWork));
            if (successor != null)
                successor.HandleRequest(item);
        }
    }
}
