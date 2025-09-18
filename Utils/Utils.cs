namespace Csharp.utils;

public static class Utils
{
    public static string ToCommaSepString<T>(this IEnumerable<T> list, string delim = ", ") => string.Join(delim, list);

    public static string Ask(string question)
    {
        Console.Write(question);
        return Console.ReadLine() ?? "";
    }

    public static int AskInt(string question, int length = -1, int min = -1, int max = -1)
    {
        while (true)
        {
            Console.Write(question);
            var input = Console.ReadLine() ?? "";
            if (!int.TryParse(input, out var value))
            {
                Console.WriteLine("Sisesta ainult täisarved!");
                continue;
            }

            if (length != -1 && input.Length != length)
            {
                Console.WriteLine($"Sisesta täisarv, mis on {length} numbrit pikk!");
                continue;
            }

            if (min != -1 && value < min)
            {
                Console.WriteLine($"Sisesta täisarv, mis on vähemalt {min}!");
                continue;
            }

            return value;
        }
    }

    public static float AskFloat(string question, float min = -1, float max = -1)
    {
        while (true)
        {
            Console.Write(question);
            var input = Console.ReadLine() ?? "";
            if (!float.TryParse(input, out var value))
            {
                Console.WriteLine("Sisesta ainult arvud!");
                continue;
            }
            if (min != -1 && value < min)
            {
                Console.WriteLine($"Sisesta arv, mis on vähemalt {min}!");
                continue;
            }
            return value;
        }
    }
}