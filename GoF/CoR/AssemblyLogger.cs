using GoF.AssemblyItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF.CoR
{
    public class AssemblyLogger : AssemblyHandlerBase
    {
        private string name;
        public AssemblyLogger(string name) : base() { this.name = name; }
        public AssemblyLogger(AssemblyHandlerBase successor, string name) : base(successor) { this.name = name; }
        public override void HandleRequest(AssemblyItem item)
        {
            Console.WriteLine($"{name}: Received item.\n{item}");
            if (successor != null)
                successor.HandleRequest(item);
        }
    }
}
