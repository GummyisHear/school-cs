using Csharp.utils;

namespace Csharp.osa4;

internal class Failid
{
    private static readonly Logger Log = new(typeof(Failid));

    public static void LisaFail(string path, string content)
    {
        File.AppendAllText(path, content + Environment.NewLine);
        Log.Info($"Rida '{content}' on lisatud faili '{path}'");
    }

    public static void KirjutaFail(string path, string content)
    {
        File.WriteAllText(path, content);
        Log.Info($"Faili '{path}' on kirjutatud sisu '{content}'");
    }

    public static List<string> LoeFail(string path)
    {
        if (!File.Exists(path))
        {
            Log.Error($"Faili '{path}' ei leitud");
            return [];
        }

        var lines = File.ReadAllLines(path).ToList();
        return lines;
    }
}
