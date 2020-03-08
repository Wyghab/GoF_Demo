using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoF.CoR;
using GoF.AssemblyItems;
using GoF.Observer;

namespace GoF
{
    class AssemblyLine : IQualityObserver
    {
        private AssemblyHandlerBase assemblyHandler;
        private List<AssemblyItem> clearedInspection;
        private List<AssemblyItem> failedInspection;
        private int testSize = 20;
        public AssemblyLine()
        {
            assemblyHandler = new AssemblyLogger("Logger");
            // SetSuccessor returns the added successor to allow nicer syntax for setting up the chain.
            assemblyHandler.SetSuccessor(new WeldStation())
                .SetSuccessor(new GlueStation())
                .SetSuccessor(new AssemblyLogger("Peeker"))
                .SetSuccessor(new QualityInspection(this));

            clearedInspection = new List<AssemblyItem>();
            failedInspection = new List<AssemblyItem>();
        }
        public void Run(string[] args)
        {
            // Throw a couple of AssemblyItems into the handler
            for (int i = 0; i < testSize; i++)
            {
                assemblyHandler.HandleRequest(new AssemblyItem());
            }
            Console.WriteLine("\nListing items that cleared final inspection:");
            foreach (AssemblyItem item in clearedInspection)
                Console.WriteLine(item);
        }

        public void OnInspectionCleared(object sender, AssemblyItem e)
        {
            clearedInspection.Add(e);
        }

        public void OnInspectionFailed(object sender, AssemblyItem e)
        {
            failedInspection.Add(e);
        }
    }
}
