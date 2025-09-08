using Csharp.utils;

namespace Csharp.osa3;

internal class FunctionsOsa3
{
    public static Random Random = new Random(69);

    public static void Ruudud()
    {
        var N = Random.Next(-100, 100);
        var M = Random.Next(-100, 100);
        var min = Math.Min(N, M);
        var max = Math.Max(N, M);
        var squares = ArvuTooltus.GenereeriRuudud(min, max);
        for (var n = min; n <= max; n++)
        {
            var i = n - min;
            Console.WriteLine($"{n} => {squares[i]}");
        }
    }

    public static void InimeseStatistika()
    {
        var inimesed = new List<Inimene>();
        Console.WriteLine("Loo 5 inimesed");
        for (int i = 0; i < 5; i++)
        {
            var inimene = new Inimene(Utils.Ask("Nimi: "), Utils.AskInt("Vanus: "));
            inimesed.Add(inimene);
        }
        var stat = FunctionsOsa3.Statistika(inimesed);
        Console.WriteLine($"Summa: {stat.Item1} Kesk: {stat.Item2} Vanim: {stat.Item3.Nimi} Noorim: {stat.Item4.Nimi}");
    }

    public static Tuple<double, double, double> AnaluusiArve(double[] arvud)
    {
        return new(arvud.Sum(), arvud.Average(), arvud.Aggregate(1.0, (acc, i) => acc * i));
    }

    public static Tuple<int, double, Inimene, Inimene> Statistika(List<Inimene> inimesed)
    {
        return new(inimesed.Sum(i => i.Vanus), inimesed.Average(i => i.Vanus), inimesed.MaxBy(i => i.Vanus)!, inimesed.MinBy(i => i.Vanus)!);
    }

    public static void KusiMarksonani(string marksona, string fraas)
    {
        var sisendid = new List<string>();
        while (true)
        {
            var sisend = Utils.Ask(fraas);
            sisendid.Add(sisend);
            if (sisend == marksona)
                break;
        }

        Console.WriteLine($"Korrektne!");
        Console.WriteLine($"Sisestatud: {sisendid.ToCommaSepString()}");
    }

    public static void ArvaArv()
    {
        var ans = Random.Next(1, 100);
        Console.WriteLine("Arva arv 1-100! 5 katset.");
        for (var i = 0; i < 5; i++)
        {
            var sisend = Utils.AskInt("Arva: ");
            if (sisend > ans)
                Console.WriteLine("Liiga suur!");
            if (sisend < ans)
                Console.WriteLine("Liiga väike!");
            if (sisend == ans)
            {
                Console.WriteLine($"Õige! Arv oli {ans}");
                break;
            }
        }
    }

    public static int SuurimNeljarv(int[] arvud)
    {
        var sorted = arvud.OrderDescending();
        return int.Parse(sorted.Aggregate("", (acc, i) => acc + i.ToString()));
    }

    public static int[,] GenereeriKorrutustabel(int rida, int veerg)
    {
        var ret = new int[rida + 1, veerg + 1];

        for (var r = 1; r < rida + 1; r++)
        for (var v = 1; v < veerg + 1; v++)
        {
            ret[r, v] = r * v;
        }

        return ret;
    }

    public static void Opilased(string[] opilaseNimed)
    {
        opilaseNimed[2] = "Kati";
        opilaseNimed[5] = "Mati";
        var i = 0;
        while (i < opilaseNimed.Length)
        {
            if (opilaseNimed[i].ToLower().StartsWith('a'))
                Console.WriteLine($"Tere {opilaseNimed[i]}");
            i++;
        }
        
        for (i = 0; i < opilaseNimed.Length; i++)
        {
            Console.WriteLine($"{i} {opilaseNimed[i]}");
        }

        foreach (var nimi in opilaseNimed)
        {
            Console.WriteLine(nimi.ToLower());
        }

        var nimi2 = "";
        i = 0;
        do
        {
            Console.WriteLine(opilaseNimed[i]);
            nimi2 = opilaseNimed[i];
            i++;
        } while (nimi2 != "Mati");


    }
}
