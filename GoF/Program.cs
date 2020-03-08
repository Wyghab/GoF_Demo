using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF
{
    class Program
    {
        public static void Main(string[] args)
        {
            AssemblyLine assemblyLine = new AssemblyLine();
            assemblyLine.Run(args);
            Console.ReadKey();
        }
    }
}
