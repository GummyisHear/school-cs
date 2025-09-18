using System.Reflection;
#nullable disable
namespace Csharp;

public class Logger
{
    private readonly string _loggerName;
    private static readonly Logger Instance = new(nameof(Logger));

    public Logger(MemberInfo type)
        : this(type.Name)
    {
    }

    public Logger(string name) 
    {
        _loggerName = name;
    }

    private static void Log(string line, string logType, ConsoleColor color, string loggerName)
    {
        var str = $"{DateTime.Now.ToString("HH:mm:ss:ffffff")}".PadRight(20);
        str = str + loggerName.PadRight(12);
        str = str + logType.PadRight(8);
        str = str + line.PadRight(5);

        var prev = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(str);
        Console.ForegroundColor = prev;
    }

    public void Info(object obj)
    {
        Log(obj.ToString(), "INFO", ConsoleColor.White, _loggerName);
    }

    public void Error(object obj)
    {
        Log(obj.ToString(), "ERROR", ConsoleColor.Red, _loggerName);
    }

    public void Warn(object obj)
    {
        Log(obj.ToString(), "WARNING", ConsoleColor.Yellow, _loggerName);
    }

    public static void Info(object obj, string loggerName = "Logger") => Log(string.Join(", ", obj), "INFO", ConsoleColor.White, loggerName);

    public static void Warn(object obj, string loggerName = "Logger") => Log(string.Join(", ", obj), "WARN", ConsoleColor.Yellow, loggerName);

    public static void Error(object obj, string loggerName = "Logger") => Log(string.Join(", ", obj), "ERROR", ConsoleColor.Red, loggerName);
}
