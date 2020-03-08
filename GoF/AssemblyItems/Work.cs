using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.AssemblyItems
{
    public class Work
    {
        public int quality;
        public WorkType workType;

        public Work(int quality, WorkType workType)
        {
            this.quality = quality;
            this.workType = workType;
        }
    }
}
