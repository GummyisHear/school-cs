namespace Csharp.utils;

public static class Utils
{
    public static string ToCommaSepString(this IEnumerable<string> list) => string.Join(", ", list);
    public static string ToCommaSepString<T>(this List<T> list) => string.Join(", ", list);

    public static string ToCommaSepString<T>(this T[] list) => string.Join(", ", list);

    public static string Ask(string question)
    {
        Console.Write(question);
        return Console.ReadLine() ?? "";
    }

    public static int AskInt(string question)
    {
        while (true)
        {
            Console.Write(question);
            var input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out var value))
                return value;

            Console.WriteLine("Sisesta ainult täisarved!");
        }
    }
}