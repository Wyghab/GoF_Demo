using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoF.AssemblyItems;

namespace GoF.CoR
{
    public abstract class AssemblyHandlerBase
    {
        protected AssemblyHandlerBase successor = null;

        public AssemblyHandlerBase() { }
        public AssemblyHandlerBase(AssemblyHandlerBase successor)
        {
            SetSuccessor(successor);
        }
        /// <summary>
        /// Sets successor for the handler, returns the added successor for better syntax flow for adding several in the chain.
        /// </summary>
        /// <param name="successor">The handler to set</param>
        /// <returns>The successor that was set</returns>
        public AssemblyHandlerBase SetSuccessor(AssemblyHandlerBase successor)
        {
            this.successor = successor;
            return successor;
        }
        public abstract void HandleRequest(AssemblyItem item);
    }
}
