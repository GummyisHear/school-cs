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

    public static void ArvudeRuudud(int[] arvud)
    {
        Console.WriteLine("for tsükkel, arve ruudud:");
        for (var i = 0; i < arvud.Length; i++)
        {
            Console.WriteLine($"{arvud[i]} => {arvud[i] * arvud[i]}");
        }

        Console.WriteLine("foreach tsükkel, kahekordne väärtused:");
        foreach (var arv in arvud)
        {
            Console.WriteLine($"{arv} => {arv * 2}");
        }

        Console.WriteLine("while tsükkel, kui palju on arve, mis jaguvad 3-ga:");
        var count = 0;
        var j = 0;
        while (j < arvud.Length)
        {
            if (arvud[j] % 3 == 0)
            {
                count++;
                Console.WriteLine($"{arvud[j]} jagub 3-ga");
            }
            j++;
        }
        Console.WriteLine($"Kokku on {count} arvu, mis jaguvad 3-ga");
    }

    public static void PositiivsedJaNegatiivset(int[] arvud)
    {
        var pos = 0;
        var neg = 0;
        var nullid = 0;
        foreach (var arv in arvud)
        {
            if (arv > 0)
                pos++;
            else if (arv < 0)
                neg++;
            else
                nullid++;
        }
        Console.WriteLine($"Arvude analüüs: {arvud.ToCommaSepString()}");
        Console.WriteLine($"Positiivsed: {pos}, Negatiivsed: {neg}, Nullid: {nullid}");
    }

    public static void KeskmisestSuuremad(int[] arvud)
    {
        Console.WriteLine($"Arvude analüüs: {arvud.ToCommaSepString()}");

        var avg = arvud.Average();
        Console.WriteLine($"Keskmine on {avg}");

        foreach (var arv in arvud)
        {
            if (arv > avg)
                Console.WriteLine($"{arv} on keskmisest suurem");
        }

        Console.WriteLine($"Arved kuni kohtad arvu, mis on väiksem kui 10");
        var i = 0;
        var arv2 = 0;
        do
        {
            arv2 = arvud[i];
            i++;
            Console.WriteLine(arv2);
        }
        while (arv2 > 10 && i < arvud.Length);
    }

    public static void KoigeSuuremOtsing(int[] arvud)
    {
        if (arvud.Length == 0)
        {
            Console.WriteLine("Arvude massiiv on tühi");
            return;
        }

        var max = arvud[0];
        var maxIndex = 0;
        for (var i = 1; i < arvud.Length; i++)
        {
            if (arvud[i] > max)
            {
                max = arvud[i];
                maxIndex = i;
            }
        }

        Console.WriteLine($"Arvude Analüüs: {arvud.ToCommaSepString()}");
        Console.WriteLine($"Kõige suurem arv on {max} indeksil {maxIndex}");
    }

    public static void PaaritudJaPaaritud(List<int> arvud)
    {
        Console.WriteLine($"Paari- ja paaritud loendused: {arvud.ToCommaSepString()}");
        var paarisSumma = 0;
        for (var i = 0; i < arvud.Count; i++)
        {
            if (arvud[i] % 2 == 0)
                paarisSumma += arvud[i];
        }
        Console.WriteLine($"Paaris arvude summa: {paarisSumma}");

        var paarituKesk = 0f;
        var paarituCount = 0;
        foreach (var arv in arvud)
        {
            if (arv % 2 != 0)
            {
                paarituKesk += arv;
                paarituCount++;
            }
        }
        paarituKesk /= paarituCount;
        Console.WriteLine($"Paaritud arvude keskmine: {paarituKesk:F2}");


        var j = 0;
        var suuremKui = 0;
        while (j < arvud.Count)
        {
            if (arvud[j] > 50)
                suuremKui++;
            j++;
        }

        Console.WriteLine($"Kokku arvu suurem kui 50: {suuremKui}");
    }   
}
