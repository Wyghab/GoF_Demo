using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoF.AssemblyItems;

namespace GoF.Observer
{
    public interface IQualityObserver
    {
        void OnInspectionCleared(object sender, AssemblyItem e);
        void OnInspectionFailed(object sender, AssemblyItem e);
    }
}
