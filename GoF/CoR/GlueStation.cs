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
        protected Random random;
        private const int randomMin = 0;
        private const int randomMax = 10;
        public GlueStation() : base() { random = new Random(); }
        public GlueStation(AssemblyHandlerBase successor) : base(successor) { random = new Random(); }
        public override void HandleRequest(AssemblyItem item)
        {
            if (item.RequiresTask(WorkType.GlueWork))
                item.PerformTask(new Work(random.Next(randomMin, randomMax+1), WorkType.GlueWork));
            successor?.HandleRequest(item);
        }
    }
}
