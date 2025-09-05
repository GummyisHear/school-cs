using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    class Program
    {
        public static Logger Log = new Logger(typeof(Program));

        static void Main(string[] args)
        {
            Functions.Pood();
        }
    }
}
