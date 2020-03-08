using GoF.AssemblyItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoF.Observer;

namespace GoF.CoR
{
    public class QualityInspection : AssemblyHandlerBase, IQualityObservable
    {
        private int qualityThreshold = 6;
        protected EventHandler<AssemblyItem> ClearedInspectionHandler { get; set; }
        protected EventHandler<AssemblyItem> FailedInspectionHandler { get; set; }
        public QualityInspection() : base() { }
        public QualityInspection(IQualityObserver observer) { Attach(observer); }
        public QualityInspection(AssemblyHandlerBase successor) : base(successor) { }
        public override void HandleRequest(AssemblyItem item)
        {
            int quality = 0;
            IReadOnlyCollection<Work> works = item.GetWorks();
            foreach (Work workItem in works)
            {
                quality += workItem.quality;
            }

            if (quality >= qualityThreshold*works.Count)
            {
                ClearedInspectionHandler?.Invoke(this, item);
                successor?.HandleRequest(item);
            }
            else
                FailedInspectionHandler?.Invoke(this, item);

        }

        public void Attach(IQualityObserver observer)
        {
            ClearedInspectionHandler += observer.OnInspectionCleared;
            FailedInspectionHandler += observer.OnInspectionFailed;
        }
    }
}
