namespace Csharp;

public class Logger
{
    public readonly string TypeName;

    public Logger(string name) 
    {
        TypeName = name;
    }

    private void Log(string line, string logType, ConsoleColor color)
    {
        var str = $"{DateTime.Now.ToString("HH:mm:ss:ffffff")}".PadRight(20);
        str = str + TypeName.PadRight(12);
        str = str + logType.PadRight(8);
        str = str + line.PadRight(5);

        var prev = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(str);
        Console.ForegroundColor = prev;
    }

    public void Info(params object[] obj)
    {
        Log(string.Join(", ", obj), "INFO", ConsoleColor.White);
    }

    public void Error(params object[] obj)
    {
        Log(string.Join(", ", obj), "ERROR", ConsoleColor.Red);
    }

    public void Warn(params object[] obj)
    {
        Log(string.Join(", ", obj), "WARNING", ConsoleColor.Yellow);
    }
}
