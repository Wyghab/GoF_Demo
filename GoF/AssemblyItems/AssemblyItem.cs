using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.AssemblyItems
{
    public class AssemblyItem
    {
        protected List<Work> completedWork;
        protected List<WorkType> uncompletedWork;

        public AssemblyItem()
        {
            completedWork = new List<Work>();
            uncompletedWork = new List<WorkType>();
            uncompletedWork.Add(WorkType.WeldWork);
            uncompletedWork.Add(WorkType.GlueWork);
        }

        public bool RequiresTask(WorkType workType) => uncompletedWork.Contains(workType);

        public void PerformTask(Work work)
        {
            uncompletedWork.Remove(work.workType);
            completedWork.Add(work);
        }

        public IReadOnlyCollection<Work> GetWorks() => completedWork.AsReadOnly();

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("AssemblyItem Instance\n\tComplete:");
            foreach (Work item in completedWork)
            {
                builder.Append($" {Enum.GetName(typeof(WorkType), item.workType)}({item.quality})");
            }
            builder.Append("\n\tUncomplete:");
            foreach (WorkType item in uncompletedWork)
            {
                builder.Append($" {Enum.GetName(typeof(WorkType), item)}");
            }
            return builder.ToString();
        }
    }
}
