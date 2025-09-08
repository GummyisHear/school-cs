namespace Csharp.Utils;

class Program
{
    public static Logger Log = new Logger(nameof(Program));
    public static Random Random = new Random(69);

    static void Main(string[] args)
    {
        Log.Info("Program started");
        List<Isik> isikud = [];

        for (int i = 0; i < 5; i++)
        {
            var isik = new Isik();
            isik.Nimi = Utils.Ask("Sisesta oma nimi: ") ?? "";
            isik.Perenimi = Utils.Ask("Sisesta oma perekonnanimi: ") ?? "";
            isikud.Add(isik);
        }
        Console.WriteLine("");
        Log.Info($"Kokku on {isikud.Count} isikud");
        Log.Info($"Sisestatud isikud: {isikud.Select(i => i.Nimi + " " + i.Perenimi).ToCommaSepString()}");
    }
}
