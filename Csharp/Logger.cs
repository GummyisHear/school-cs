using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    public class Logger
    {
        public readonly string TypeName;

        public Logger(Type type) 
        {
            TypeName = type.Name;
        }

        private void Log(string str, ConsoleColor color)
        {
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = prev;
        }

        public void Info(params object[] obj)
        {
            var line = string.Join(", ", obj);
            var str = $"{DateTime.Now.ToString("HH:mm:ss:ffffff")}".PadRight(20);
            str = str + TypeName.PadRight(12);
            str = str + "INFO".PadRight(8);
            str = str + line.PadRight(5);

            Log(str, ConsoleColor.White);
        }

        public void Error(params object[] obj)
        {
            var line = string.Join(", ", obj);
            var str = $"{DateTime.Now.ToString("HH:mm:ss:ffffff")}".PadRight(20);
            str = str + TypeName.PadRight(12);
            str = str + "ERROR".PadRight(8);
            str = str + line.PadRight(5);

            Log(str, ConsoleColor.Red);
        }

        public void Warn(params object[] obj)
        {
            var line = string.Join(", ", obj);
            var str = $"{DateTime.Now.ToString("HH:mm:ss:ffffff")}".PadRight(20);
            str = str + TypeName.PadRight(12);
            str = str + "WARNING".PadRight(8);
            str = str + line.PadRight(5);

            Log(str, ConsoleColor.Yellow);
        }
    }
}
